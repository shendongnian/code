    namespace Win
    {
        using System.Management;
        using System.Threading;
        using System.Diagnostics;
        using System.IO;
        public class OpenWithDialogHelper : IDisposable
        {
            #region members
            private Process openWithProcess;
            private ManagementEventWatcher monitor;
            public string Filepath { get; set; }
            public Process AppProcess { get; private set; }
        
            #endregion
            #region .ctor
            public OpenWithDialogHelper()
            {
            }
            public OpenWithDialogHelper(string filepath)
            {
                this.Filepath = filepath;
            }
            #endregion
            #region methods
            public void OpenFileAndWaitForExit(int milliseconds = 0)
            {
                OpenFileAndWaitForExit(this.Filepath, milliseconds);
            }
            public void OpenFileAndWaitForExit(string filepath, int milliseconds = 0)
            {
                this.Filepath = filepath;
                this.openWithProcess = new Process();
                this.openWithProcess.StartInfo.FileName = "rundll32.exe";
                this.openWithProcess.StartInfo.Arguments = String.Format("shell32.dll,OpenAs_RunDLL \"{0}\"", filepath);
                this.openWithProcess.Start();
            
                //using WMI, remarks to add System.Management.dll as reference!
                this.monitor = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
                this.monitor.EventArrived += new EventArrivedEventHandler(start_EventArrived);
                this.monitor.Start();
                this.openWithProcess.WaitForExit();
    
                //catching the app process...
                //it can't catched when the process was closed too soon
                //or the user clicked Cancel and no application was opened
                Thread.Sleep(1000);
                int i = 0;
                //wait max 5 secs...
                while (this.AppProcess == null && i < 3000)
                {
                    Thread.Sleep(100); i++; 
                }
                if (this.AppProcess != null)
                {
                    if (milliseconds > 0)
                        this.AppProcess.WaitForExit(milliseconds);
                    else
                        this.AppProcess.WaitForExit();
                }
            }
            public void Dispose()
            {
                if (this.monitor != null)
                {
                    this.monitor.EventArrived -= new EventArrivedEventHandler(start_EventArrived);
                    this.monitor.Dispose();
                }
                if(this.openWithProcess != null)
                    this.openWithProcess.Dispose();
                if (this.AppProcess != null)
                    this.AppProcess.Dispose();
            }
            #endregion
            #region events
            private void start_EventArrived(object sender, EventArrivedEventArgs e)
            {
                int parentProcessID = Convert.ToInt32(e.NewEvent.Properties["ParentProcessID"].Value);
                //The ParentProcessID of the started process must be the OpenAs_RunDLL process
                //NOTICE: It doesn't recognice windows photo viewer
                // - which is a dllhost.exe that doesn't have the ParentProcessID
                if (parentProcessID == this.openWithProcess.Id)
                {
                    this.AppProcess = Process.GetProcessById(Convert.ToInt32(
                        e.NewEvent.Properties["ProcessID"].Value));
                    if (!this.AppProcess.HasExited)
                    {
                        this.AppProcess.EnableRaisingEvents = true;
                    }
                }
            }    
            #endregion
        }
    }
