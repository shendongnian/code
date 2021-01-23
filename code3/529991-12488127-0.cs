    public static class MyProc
        {
            public static IntPtr WoWhWnd;
            public static string WoWProcName;
            public static string WowMainWinTitle;
            public static int WowID;
            public static IntPtr MyApphWnd;
            public static string MyAppProcName;
            public static string MyAppMainWinTitle;
            public static int MyAppID;
        }
        public void bring(string handletoFront)
        {
            switch (handletoFront)
            {
                default:
                    
                    SetForegroundWindow(MyProc.WoWhWnd);
                    break;
                case "MyApp":
                    SetForegroundWindow(MyProc.MyApphWnd);
                                        break;
            }
        }
               #region <<=========== Enumerating Processes   ============>>
            void  ShowP1(){
                IEnumerable<Process> processes = from p in Process.GetProcesses() where p.ProcessName.StartsWith(TBXSearchWindowTerm.Text) || p.ProcessName.StartsWith("WindowsF") orderby p.ProcessName select p;
                MyProc.MyApphWnd = processes.ElementAt(1).MainWindowHandle;
                MyProc.MyAppMainWinTitle = processes.ElementAt(1).MainWindowTitle;
                MyProc.MyAppID = processes.ElementAt(1).Id;
                MyProc.WoWhWnd = processes.ElementAt(0).MainWindowHandle;
                MyProc.WowMainWinTitle = processes.ElementAt(0).MainWindowTitle;
                MyProc.WowID = processes.ElementAt(0).Id;
                pause(350);
                SetForegroundWindow(MyProc.WoWhWnd);
                pause(850);
                SetForegroundWindow(MyProc.MyApphWnd);
            }
