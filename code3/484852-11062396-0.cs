        /// <summary>
        /// Gets the bitmap.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static BitmapSource GetBitmap(string path)
        {
            if (!File.Exists(path)) return null;
            MemoryStream ms = new MemoryStream();
            BitmapImage bi = new BitmapImage();
            byte[] bytArray = File.ReadAllBytes(path);
            ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }
