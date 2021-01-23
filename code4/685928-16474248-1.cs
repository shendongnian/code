    private void rtbComputerstatus_MouseMove(object sender, MouseEventArgs e)
    {
        Point  cursorPoint = Cursor.Position;
        Bitmap bm = new Bitmap(1, 1);
        Graphics g  = Graphics.FromImage(bm);
        g.CopyFromScreen(cursorPoint, new Point(), new Size(1, 1));
        Color pixelColor = bm.GetPixel(0, 0);
        g.Dispose();
        bm.Dispose();
        if (pixelColor.ToArgb().Equals(Color.Blue.ToArgb()))
        {
            if (rtbComputerstatus.Cursor != Cursors.Hand)
                rtbComputerstatus.Cursor = Cursors.Hand;
        }
        else
        {
            if(rtbComputerstatus.Cursor != Cursors.Default)
                rtbComputerstatus.Cursor = Cursors.Default;
        }
    }
