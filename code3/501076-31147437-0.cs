                    Exception threadEccezione = null;
                    System.Threading.Thread staThread = new System.Threading.Thread(
                            delegate()
                            {
                                try
                                {
                                    //SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
                                    var explorer = new SHDocVw.ShellWindowsClass().Cast<SHDocVw.InternetExplorer>().Where(hwnd => hwnd.HWND == handle).FirstOrDefault();
                                    if (explorer != null)
                                    {
                                        string path = new Uri(explorer.LocationURL).LocalPath;
                                        MessageBox.Show(path);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    threadEccezione = ex;
                                }
                            }
                        );
                    ;
                    staThread.Start();
                    staThread.Join();
