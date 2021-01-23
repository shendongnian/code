                    Image image = ...;
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (ms.Length == 0)
                    {
                        ms.Close();
                        throw new Exception("Bad Image File");
                    }
                    ms.Position = 0;
                    byte[] baImageBytes = new byte[ms.Length];
                    ms.Read(baImageBytes , 0, (int)ms.Length);
                    ms.Close();
