    PB.Paint += new PaintEventHandler((sender, e) =>
    {
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    
        string text = "Text";
    
        SizeF textSize = e.Graphics.MeasureString(text, Font);
        PointF locationToDraw = new PointF();
        locationToDraw.X = (PB.Width / 2) - (textSize.Width / 2);
        locationToDraw.Y = (PB.Height / 2) - (textSize.Height / 2);
    
        e.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
    });
