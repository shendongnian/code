    using Autodesk.AutoCAD.Interop;
    using Autodesk.AutoCAD.Interop.Common;
    namespace YourNameSpace {
    public class YourClass {
    AcadApplication AcApp;
    private const string progID = "AutoCAD.Application.18.2";// this is AutoCAD 2012 program id
    private string profileName = "<<Unnamed Profile>>";
    private const string acadPath = @"C:\Program Files\Autodesk\AutoCAD 2012 - English\acad.exe";
    public void GetAcApp()
		{
			try
			{
				AcApp = (AcadApplication)Marshal.GetActiveObject(progID);
				
			} catch {
				try {
					var acadProcess = new Process();
					acadProcess.StartInfo.Arguments = string.Format("/nologo /p \"{0}\"", profileName);
					acadProcess.StartInfo.FileName = (@acadPath);
					acadProcess.Start();
					while(AcApp == null)
					{
						try { AcApp = (AcadApplication)Marshal.GetActiveObject(progID); }
						catch { }
					}
				} catch(COMException) {
					MessageBox.Show(String.Format("Cannot create object of type \"{0}\"",progID));
				}
			}
			try {
				int i = 0;
				var appState = AcApp.GetAcadState();
				while (!appState.IsQuiescent)
				{
					if(i == 120)
					{
						Application.Exit();
					}
					// Wait .25s
					Thread.Sleep(250);
					i++;
				}
				if(AcApp != null){
					// set visibility
					AcApp.Visible = true;
				}
			} catch (COMException err) {
				if(err.ErrorCode.ToString() == "-2147417846"){
					Thread.Sleep(5000);
				}
			}
		}
        }
    }
