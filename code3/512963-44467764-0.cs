    public class VBitmap : IDisposable
    {        
    
        public short Width { get; private set; }
        public short Height { get; private set; }
        public int Stride { get; private set; }
        public int PixelLenght { get; private set; }
        public byte BytesperPixel { get; private set; }
        public PixelFormat PixelFormat { get; private set; }
        public byte[] Pixels { get; private set; }
    
        public VBitmap(string path)
        {
            using (Bitmap bmp = new Bitmap(path))
            {
                BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                Width = checked((short)bmp.Width);
                Height = checked((short)bmp.Height);
                Stride = bmpdata.Stride;
                PixelLenght = Stride * Height;
                BytesperPixel = checked((byte)(Stride / Width));
                PixelLenght = (PixelLenght % 16) != 0 ? PixelLenght + (PixelLenght % 16) : PixelLenght;
                PixelFormat = bmp.PixelFormat;
                Pixels = new byte[PixelLenght];
    
                Marshal.Copy(bmpdata.Scan0, Pixels, 0, PixelLenght);
                bmp.UnlockBits(bmpdata);
            }
        }
        ~VBitmap()
        {
            Dispose();
        }
    
        public void InvertPixels()
        {
            byte[] resultarray = Pixels;
            unsafe
            {
                fixed (byte* result_ptr = resultarray)
                {
                    for (int i = 0; i < PixelLenght; i += 16)
                        (~new Vector<byte>(Pixels, i)).CopyTo(resultarray, i);
                }
            }
        }
    
        public void InvertPixels(string name)
        {
            byte[] resultarray = Pixels;
            unsafe
            {
                fixed (byte* result_ptr = resultarray)
                {
                    for (int i = 0; i < PixelLenght; i += 16)
                        (~new Vector<byte>(Pixels, i)).CopyTo(resultarray, i);
                    SaveImage(name);
                }
            }
        }
    
        public unsafe void SaveImage(string name)
        {
            fixed (byte* p_ptr = Pixels)
            {
                using (Bitmap resultbmp = new Bitmap(Width, Height, Stride, PixelFormat, (IntPtr)p_ptr))
                {
                    resultbmp.Save(name, ImageFormat.Jpeg);
                }
            }
        }
    
        public void Dispose()
        {
            Width = 0;
            Height = 0;
            Stride = 0;
            PixelLenght = 0;
            BytesperPixel = 0;
            Pixels = null;
            GC.Collect();
        }
    }
