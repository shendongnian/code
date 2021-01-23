    //global scope
    Bitmap screenPixel = new Bitmap(1, 1);
    Color c = Color.Black 
    
    //method to test
    using (Graphics gdest = Graphics.FromImage(screenPixel))
    {
        using (Graphics gsrc = Graphics.FromHwnd(hWnd))
        {
            IntPtr hSrcDC = gsrc.GetHdc();
            IntPtr hDC = gdest.GetHdc();
            int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, xVal, 540, (int)CopyPixelOperation.SourceCopy);
            gdest.ReleaseHdc();
            gsrc.ReleaseHdc();
        }
    }
    c = screenPixel.GetPixel(0, 0);
