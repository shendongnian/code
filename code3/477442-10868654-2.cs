    private void doc_PrintPage(object sender, PrintPageEventArgs ev)
    {
        var bitmap = new Bitmap((int)graphics.ClipBounds.Width,
                                (int)graphics.ClipBounds.Height);
        using (var g = Graphics.FromImage(bitmap))
        {
            // Draw all the graphics using into g (into the bitmap)
            g.DrawLine(Pens.Black, 0, 0, 100, 100);
        }
        // And maybe some control drawing if you want...?
        this.label1.DrawToBitmap(bitmap, this.label1.Bounds);
        ev.Graphics.DrawImage(bitmap, 0, 0);
    }
