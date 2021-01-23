        IDataObject data = null;
                    Exception threadEx = null;
                    Thread staThread = new Thread(
                        delegate()
                        {
                            try
                            {
                                data = Clipboard.GetDataObject();
                                if (data.GetDataPresent(DataFormats.Bitmap))
                                {
                                    Bitmap bmp = (System.Drawing.Bitmap)data.GetData(DataFormats.Bitmap);
                                    string filename = String.Format(@"c:\image{0}.bmp", i.ToString());
                                    bmp.Save(filename);
                                }
                            }
                            catch (Exception ex)
                            {
                                threadEx = ex;
                            }
                        });
                    staThread.SetApartmentState(ApartmentState.STA);
                    staThread.Start();
                    staThread.Join();
