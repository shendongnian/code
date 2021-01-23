        public static Bitmap ConvertTo8bpp(Image img) {
            var ms = new System.IO.MemoryStream();   // Don't use using!!!
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            ms.Position = 0;
            return new Bitmap(ms);
        }
