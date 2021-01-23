    internal unsafe sealed class FastImageCroper : IDisposable
    {
        private readonly Bitmap _srcImg;
        private readonly BitmapData _srcImgBitmapData;
        private readonly int _bpp;
        private readonly byte* _srtPrt;
        public FastImageCroper(Bitmap srcImg)
        {
            _srcImg = srcImg;
            _srcImgBitmapData = srcImg.LockBits(new Rectangle(0, 0, srcImg.Width, srcImg.Height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
            _bpp = _srcImgBitmapData.Stride / _srcImgBitmapData.Width; // == 4
            _srtPrt = (byte*)_srcImgBitmapData.Scan0.ToPointer();
        }
        public Bitmap Crop(Rectangle rectangle)
        {
            Bitmap dstImg = new Bitmap(rectangle.Width, rectangle.Height, _srcImg.PixelFormat);
            BitmapData dstImgBitmapData = dstImg.LockBits(new Rectangle(0, 0, dstImg.Width, dstImg.Height), ImageLockMode.WriteOnly, dstImg.PixelFormat);
            byte* dstPrt = (byte*)dstImgBitmapData.Scan0.ToPointer();
            byte* srcPrt = _srtPrt + rectangle.Y*_srcImgBitmapData.Stride + rectangle.X*_bpp;
            for (int y = 0; y < rectangle.Height; y++)
            {
                int srcIndex =  y * _srcImgBitmapData.Stride;
                int croppedIndex = y * dstImgBitmapData.Stride;
                memcpy(dstPrt + croppedIndex, srcPrt + srcIndex, dstImgBitmapData.Stride);
            }
            dstImg.UnlockBits(dstImgBitmapData);
            return dstImg;
        }
        public void Dispose()
        {
            _srcImg.UnlockBits(_srcImgBitmapData);
        }
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcpy(byte* dest, byte* src, long count);
    }
