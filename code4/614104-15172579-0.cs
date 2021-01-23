    protected void Chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
      if (e.ChartElement is Chart)
    {
    // create text to draw
    String TextToDraw;
    TextToDraw = "Chart Label"
    // get graphics tools
    Graphics g = e.ChartGraphics.Graphics;
    Font DrawFont = System.Drawing.SystemFonts.CaptionFont;
    Brush DrawBrush = Brushes.Black;
    // see how big the text will be
    int TxtWidth = (int)g.MeasureString(TextToDraw, DrawFont).Width;
    int TxtHeight = (int)g.MeasureString(TextToDraw, DrawFont).Height;
    // where to draw
    int x = 5;  // a few pixels from the left border
    int y = (int)e.Chart.Height.Value;
    y = y - TxtHeight - 5; // a few pixels off the bottom
    // draw the string        
    g.DrawString(TextToDraw, DrawFont, DrawBrush, x, y);
    }
