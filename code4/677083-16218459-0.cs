    public static class Ext
    {
        public static byte[] GetBytes(this Bitmap bitmap)
        {
            var bytes = new byte[bitmap.Height * bitmap.Width * 3];
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                    ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            Marshal.Copy(bitmapData.Scan0, bytes, 0, bytes.Length);
            bitmap.UnlockBits(bitmapData);
            return bytes;
        }
    }
    var bitmap = new Bitmap(@"C:\myimg.jpg");
    var bitmap1 = new Bitmap(@"C:\myimg.jpg");
    var bytes = bitmap.GetBytes();
    var bytes1 = bitmap1.GetBytes();
    //true
    var sequenceEqual = bytes.SequenceEqual(bytes1);
