            [DllImport("user32.dll")]
            static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
            
            [DllImport("user32.dll")]
            static extern bool CloseWindow(IntPtr hWnd);
    
            [DllImport("user32")]
            private static extern bool SetForegroundWindow(IntPtr hwnd);
    
            public const int WM_SYSCOMMAND = 0x0112;
            public const int SC_CLOSE = 0xF060;
    
            private void button1_Click(object sender, EventArgs e)
            {
                var proc = Process.GetProcesses().OrderBy(x => x.ProcessName);
    
                foreach (Process prs in proc)
                    if (prs.ProcessName == "chrome" && WmiTest(prs.Id))
                    {
                        prs.Kill();
    
                        //To test SendKeys, not working, but gives you the idea
                        //SetForegroundWindow(prs.Handle);
                        //SendKeys.Send("%({F4})");
                    }
            }
    
            private bool WmiTest(int processId)
            {
                using (ManagementObjectSearcher mos = new ManagementObjectSearcher(string.Format("SELECT CommandLine FROM Win32_Process WHERE ProcessId = {0}", processId)))
                    foreach (ManagementObject mo in mos.Get())
                        if (mo["CommandLine"].ToString().Contains("--disable-databases"))
                            return true;
                return false;
            }
