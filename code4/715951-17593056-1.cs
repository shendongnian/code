    System.Diagnostics.Process[] uWebCam = Process.GetProcessesByName("asd.vshost");
                if (uWebCam .Length > 0)
                {
                    foreach (System.Diagnostics.Process p in uWebCam )
                    {
                        IntPtr handle = p.MainWindowHandle;
                        EnumChildWindows(handle, EnumChildProc, 0);
                    }
                }
                else
                {
                    MessageBox.Show("Process can not found!");
                }
