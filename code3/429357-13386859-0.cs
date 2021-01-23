        public static BitmapSource LoadBitmap(ImagingFactory2 factory, string filename)
        {
            var bitmapDecoder = new SharpDX.WIC.BitmapDecoder(
                factory,
                filename,
                SharpDX.WIC.DecodeOptions.CacheOnDemand
                );
            var result = new SharpDX.WIC.FormatConverter(factory);
            result.Initialize(
                bitmapDecoder.GetFrame(0),
                SharpDX.WIC.PixelFormat.Format32bppPRGBA,
                SharpDX.WIC.BitmapDitherType.None, 
                null,
                0.0, 
                SharpDX.WIC.BitmapPaletteType.Custom);
            return result;
        }
