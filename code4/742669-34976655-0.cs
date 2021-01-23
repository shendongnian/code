                       {
                        //Application.DoEvents();
                        Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        Graphics graphics = Graphics.FromImage(printscreen as Image);
                        graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                        string path = "";
                        if (forLog)
                        {
                            path = LoggerPath + StudentNumber.ToString() + "\\" + SessionID.ToString() + "\\";
                        }
                        else
                        {
                            path = PrintScreenPath + StudentNumber.ToString() + "\\" + SessionID.ToString() + "\\";
                        }
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        string fileName = DateTime.Now.Ticks.ToString();
                        SaveJPGWithCompressionSetting(printscreen, path + fileName + ".jpeg", 17L);
                        printscreen.Dispose();
                        graphics.Dispose();
                        return fileName;
                    }
