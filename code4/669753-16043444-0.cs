           public ActionResult GenerateImage()
                {
                    FileContentResult result;
                    System.Drawing.Image objImage = null;
                  ....
                    mpr = MySession.Current.mpr2;
                    im = mpr;
                   ...
                    objImage = im.Bitmap(outputSize,  
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb, m);
                    using (var memStream = new MemoryStream())
                    {
                        objImage.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
                        result = this.File(memStream.GetBuffer(), "image/png");
                    }
        
                    return result;
                }
