    Bitmap b = new Bitmap(100,100);
    var bits = b.LockBits(new Rectangle(0,0,100,100), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    Random rand = new Random();
    var pixels = Enumerable.Range(1, 100*100).Select(n => rand.Next()).ToArray();
    Marshal.Copy(pixels, 0, bits.Scan0, 100*100);
    b.UnlockBits(bits);
    // use the image ...
    b.Save("D:\\test.png", ImageFormat.Png);
