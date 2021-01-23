        public static byte[] SaveToPng(this BitmapSource bitmapSource)
        {
            return SaveWithEncoder<PngBitmapEncoder>(bitmapSource);
        }
        private static byte[] SaveWithEncoder<TEncoder>(BitmapSource bitmapSource) where TEncoder : BitmapEncoder, new()
        {
            if (bitmapSource == null) throw new ArgumentNullException("bitmapSource");
            using (var msStream = new MemoryStream())
            {
                var encoder = new TEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(msStream);
                return msStream.ToArray();
            }
        }
		public static BitmapSource ReadBitmap(Stream imageStream)
		{
			BitmapDecoder bdDecoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
			return bdDecoder.Frames[0];
		}
