    protected override void OnPaint(PaintEventArgs e)
    {
        // This is where we wish to print our string
        var region = new RectangleF(50, 50, 200, 50);
        // This is the font we wish to use
        var font = new Font("Times New Roman", 16.0F);
        // Draw a string for comparison
        DrawString(e.Graphics, "RedBlack", font, Brushes.Black, new RectangleF(50, 150, 200, 50));
        // Draw the first string and keep a track of the Region it was rendered in
        var first = DrawString(e.Graphics, "Red", font, Brushes.Red, region);
        // Adjust the region we wish to print 
        region = new RectangleF(region.X + first.GetBounds(e.Graphics).Width, region.Y, region.Width, region.Height);
        // Draw the second string
        DrawString(e.Graphics, "Black", font, Brushes.Black, region);
        base.OnPaint(e);
    }
    private Region DrawString(Graphics g, string s, Font font, Brush brush, RectangleF layoutRectangle)
    {
        var format = new StringFormat();
        format.SetMeasurableCharacterRanges(new[] { new CharacterRange(0, s.Length) });
        g.DrawString(s, font, brush, layoutRectangle, format);
        return g.MeasureCharacterRanges(s, font, layoutRectangle, format)[0];
    }
