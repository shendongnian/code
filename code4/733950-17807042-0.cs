    private static byte[] Resize(byte[] imageBytes, int width, int height)
        {
            using (var imagestream = new MemoryStream(imageBytes))
            {
                using (var img = Image.FromStream(imagestream))
                {
                    using (var outStream = new MemoryStream())
                    {
                        double y = img.Height;
                        double x = img.Width;
    
                        double factor = 1;
                        if (width > 0)
                            factor = width / x;
                        else if (height > 0)
                            factor = height / y;
    
                        using (var imgOut = new Bitmap((int)(x * factor), (int)(y * factor)))
                        {
                            using (var g = Graphics.FromImage(imgOut))
                            {
                                g.Clear(Color.White);
                                g.DrawImage(img, new Rectangle(0, 0, (int)(factor * x),
                                                       (int)(factor * y)),
                                    new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);
                            }
    
                            imgOut.Save(outStream, ImageFormat.Jpeg);
                        }
    
                        return outStream.ToArray();
                    }
                }
            }
     }
