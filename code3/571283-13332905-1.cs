    public static void ScreenShot()
    {
        var destBitmap = new Bitmap(500, 500);
        using (var destGraph = Graphics.FromImage(destBitmap))
        {
            destGraph.CopyFromScreen(new Point(), new Point(), destBitmap.Size);
        }
        destBitmap.Save(@"c:\bla.png");
    }
