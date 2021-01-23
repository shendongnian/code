        // extension method
        public static byte[] imageToByteArray(this System.Drawing.Image image)
        {
            using(var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
