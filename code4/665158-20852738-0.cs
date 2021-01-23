    BitmapData data2 =   c.LockBits(new System.Drawing.Rectangle(0, 
                                                   0, 
                                                   c.Width,
                                                   c.Height),
                        ImageLockMode.ReadOnly,
                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);
