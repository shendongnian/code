    static void Main(string[] args)
    {
        Rectangle rect = Screen.PrimaryScreen.Bounds;
        int color = Screen.PrimaryScreen.BitsPerPixel;
        PixelFormat pf;
        pf = PixelFormat.Format32bppArgb;           
        Bitmap BM = new Bitmap(rect.Width, rect.Height, pf);
        Graphics g = Graphics.FromImage(BM);
        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
        Bitmap bitamp = new Bitmap(BM);
        print(bitamp); // what now?
    }
    private static void print(Bitmap BM)
    {
        Graphics graphicsObj = Graphics.FromImage(BM);
        graphicsObj.DrawImage(BM, 60, 10); // or "e.Graphics.DrawImage(bitmap, 60, 10);"
        graphicsObj.Dispose();
    }
