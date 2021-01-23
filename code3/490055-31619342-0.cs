    if (overlay != null) overlay.Dispose();
    //--------------------------------------------- code given by AAAA
    Thread t = new Thread(new ThreadStart(delegate
    {
        Thread.Sleep(500);
        GC.Collect();
    }));
    t.Start();
    //-------------------------------------------- \code given by AAAA
    overlay = new Bitmap(backDrop);
    Graphics g = Graphics.FromImage(overlay);
