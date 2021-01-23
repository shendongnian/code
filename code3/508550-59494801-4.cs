      public static class ConvertTiffToJpeg
        {
            static string base64String = null;
            public static string ImageToBase64(string tifpath)
            {
                string path = tifpath;
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, ImageFormat.Jpeg);
                        byte[] imageBytes = m.ToArray();
                        base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }
        }
