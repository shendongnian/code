    void Main()
    {
        var a = (Bitmap)Image.FromFile("image1.png");
        var b = (Bitmap)Image.FromFile("image2.png");
        var diff = PixelDiff(a, b);
    }
    
    unsafe Bitmap PixelDiff(Bitmap a, Bitmap b)
    {
        Bitmap output = new Bitmap(a.Width, a.Width, PixelFormat.Format32bppArgb);
        Rectangle rect = new Rectangle(Point.Empty, a.Size);
        using (var aData = a.LockBitsDisposable(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
        using (var bData = b.LockBitsDisposable(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb))
        using (var outputData = output.LockBitsDisposable(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb))
        {
            byte* aPtr = (byte*)aData.Scan0;
            byte* bPtr = (byte*)bData.Scan0;
            byte* outputPtr = (byte*)outputData.Scan0;
            int len = aData.Stride * aData.Height;
            for (int i = 0; i < len; i++)
            {
                // For alpha use the average of both images (otherwise pixels with the same alpha won't be visible)
                if ((i + 1) % 4 == 0)
                    *outputPtr = (byte)((*aPtr  + *bPtr) / 2);
                else
                    *outputPtr = (byte)~(*aPtr ^ *bPtr);
                
                outputPtr++;
                aPtr++;
                bPtr++;
            }
        }
        return output;
    }
    
    static class Extensions
    {
        public static DisposableImageData LockBitsDisposable(this Bitmap bitmap, Rectangle rect, ImageLockMode flags, PixelFormat format)
        {
            return new DisposableImageData(bitmap, rect, flags, format);
        }
    
        public class DisposableImageData : IDisposable
        {
            private readonly Bitmap _bitmap;
            private readonly BitmapData _data;
        
            internal DisposableImageData(Bitmap bitmap, Rectangle rect, ImageLockMode flags, PixelFormat format)
            {
                bitmap.CheckArgumentNull("bitmap");
                _bitmap = bitmap;
                _data = bitmap.LockBits(rect, flags, format);
            }
            
            public void Dispose()
            {
                _bitmap.UnlockBits(_data);
            }
            
            public IntPtr Scan0
            {
                get { return _data.Scan0; }
            }
            
            public int Stride
            {
                get { return _data.Stride;}
            }
            
            public int Width
            {
                get { return _data.Width;}
            }
            
            public int Height
            {
                get { return _data.Height;}
            }
            
            public PixelFormat PixelFormat
            {
                get { return _data.PixelFormat;}
            }
            
            public int Reserved
            {
                get { return _data.Reserved;}
            }
        }   
    }
