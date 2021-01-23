    private static void CompareBitmaps(Bitmap a, Bitmap b) {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var lockRect = new Rectangle(0, 0, a.Width, a.Height);
        BitmapData ad = a.LockBits(lockRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        BitmapData bd = b.LockBits(lockRect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        Int32[] apixels = new Int32[ad.Width * ad.Height];
        Int32[] bpixels = new Int32[bd.Width * bd.Height];
        Marshal.Copy(ad.Scan0, apixels, 0, apixels.Length);
        Marshal.Copy(bd.Scan0, bpixels, 0, bpixels.Length);
        for(int i = 0; i < apixels.Length; i++) {
            if(apixels[i] != bpixels[i]) {
                unchecked {
                    bpixels[i] = (int)0xff5a0000;
                }
            }
        }
        Marshal.Copy(bpixels, 0, bd.Scan0, bpixels.Length);
        a.UnlockBits(ad);
        b.UnlockBits(bd);
        sw.Stop();
        Console.WriteLine("CompareBitmaps took {0}.", sw.Elapsed);
    }
