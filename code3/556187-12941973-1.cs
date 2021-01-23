	using System;
	using System.Windows.Forms;
	using CSScriptTest;
	class Script : MarshalByRefObject, CSScriptTest.IScript
	{ 
		public void AddUserControl(CSScriptTest.Form1 host)
		{
			host.AddUserControl1(this, "lol2");
		}
	}
