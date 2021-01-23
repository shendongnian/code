        string ToBase64(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        string ToBase64(BitmapSource bitmapSource)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        Bitmap FromBase64(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            using (var stream = new MemoryStream(Convert.FromBase64String(value)))
            {
                return (Bitmap)Image.FromStream(stream);
            }
        }
        BitmapSource BitmapSourceFromBase64(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            using (var stream = new MemoryStream(Convert.FromBase64String(value)))
            {
                var decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                BitmapSource result = decoder.Frames[0];
                result.Freeze();
                return result;
            }
        }
