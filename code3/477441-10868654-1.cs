    private void doc_PrintPage(object sender, PrintPageEventArgs ev)
    {
        // Create a bitmap object with the dimensions and resolution of the Print Graphics
        var bitmap = new Bitmap((int)ev.Graphics.ClipBounds.Width,
                                (int)ev.Graphics.ClipBounds.Height, ev.Graphics);
        using (var g = Graphics.FromImage(bitmap))
        {
            // Draw all the graphics using into g (into the bitmap)
            g.DrawLine(Pens.Black, 0, 0, 100, 100);
        }
        // And maybe some control drawing if you want...?
        this.label1.DrawToBitmap(bitmap, this.label1.Bounds);
        ev.Graphics.DrawImage(bitmap, 0, 0);
    }
