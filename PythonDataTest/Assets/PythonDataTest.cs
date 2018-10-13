using UnityEngine;
using System.Collections;

public class PythonDataTest : MonoBehaviour
{
	string m_Path;

	System.Diagnostics.Process p;

	int i;

	void Start ()
	{
		Screen.fullScreen = !Screen.fullScreen;
		i = 0;
		m_Path = Application.dataPath;

		//Output the Game data path to the console
		//Debug.Log("Path : " + m_Path);

		/*p = new System.Diagnostics.Process();
		p.StartInfo.FileName = m_Path + "/pythontest.py";
		p.StartInfo.Arguments = "optional arguments separated with spaces";
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.RedirectStandardError = true;
		p.Start();  */

		Debug.Log ("Start read");


		p = new System.Diagnostics.Process();
		p.StartInfo.RedirectStandardError = true;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.UseShellExecute = false;
		//p.StartInfo.CreateNoWindow = true;
		//p.EnableRaisingEvents = true;
		//p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		p.StartInfo.FileName = m_Path + "/webcam-pulse-detector-no_openmdao/get_pulse.py";
		//p.StartInfo.FileName = m_Path + "/pythontest.py";
		//p.StartInfo.Arguments = "optional arguments separated with spaces";

		p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(
			(s, e) => 
			{ 
				Debug.Log("DATA: " + i + " - " + e.Data); 
				Debug.Log(s);
			}
		);
		p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(
			(s, e) => { 
				Debug.Log("ERROR:" + i + " - " + e.Data); 
			}
		);

		p.Start();
		p.BeginOutputReadLine ();
	
		Debug.Log("Read end");
	}

	// Update is called once per frame
	void Update () {

		i = i + 1;

		//Debug.Log (p.StandardOutput.ReadToEnd ());

	}
}