            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                if (!isStillRunning())
                {
                   Application.Run(new Form1());
                 }
                 else {
                     MessageBox.Show("Previous process still running.",
                        "Application Halted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     Application.Exit();
                 }      
            }
             
            //***Uses WMI Query
            static bool isStillRunning() {
                string processName = Process.GetCurrentProcess().MainModule.ModuleName;
                ManagementObjectSearcher mos = new ManagementObjectSearcher();
                mos.Query.QueryString = @"SELECT * FROM Win32_Process WHERE Name = '" + processName + @"'";
                if (mos.Get().Count > 1)
                {
                   return true;
                }
                else
                   return false;
            }
