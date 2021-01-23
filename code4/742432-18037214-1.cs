    private byte[] ImageToByte(System.Drawing.Image imageToConvert,
                                                       System.Drawing.Imaging.ImageFormat formatOfImage)
                {
                    byte[] Ret;
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            imageToConvert.Save(ms, formatOfImage);
                            Ret = ms.ToArray();
                        }
                    }
                    catch (Exception) { throw; }
                    return Ret;
                }
