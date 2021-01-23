                                FileInfo fileinfo = new FileInfo(MyFilePath);
                                if (fileinfo.Exists)
                                {
                                    using (FileStream fs = System.IO.File.Open(MyFilePath,
                                                        FileMode.Open,
                                                        FileAccess.Read,
                                                        FileShare.ReadWrite))
                                    {
                                        using (StreamReader reader = new StreamReader(fs))
                                        {
         
                                            BitmapImage bitImg = new BitmapImage();
                                            bitImg.BeginInit();
                                            bitImg.StreamSource = fs;
                                            bitImg.EndInit();
                                            Image.ImageSource = bitImg;
                                           
                                        }
                                    }
                                }
