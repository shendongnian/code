    // I'm generating the glyphs differently for testing.
    // I tested with fontName="Arial"
    Typeface face = new Typeface(fontName);
    GlyphTypeface font;
    if (!face.TryGetGlyphTypeface(out font))
        return; // bail if something goes wrong
            
    int ColumnCount = 10;
    int MaxDrawCount = 30; // use int.MaxValue to draw them all            
    double fontSize = 50d;
    // the height of each cell has to include over/underhanging glyphs
    Size cellSize = new Size(fontSize, fontSize * font.Height);
    var Glyphs = from glyphIndex in font.CharacterToGlyphMap.Values
                        select font.GetGlyphOutline(glyphIndex, fontSize, 1d);            
    // now create the visual we'll draw them to
    DrawingVisual viz = new DrawingVisual();
    int drawCount = -1;
    using (DrawingContext dc = viz.RenderOpen())
    {
        foreach (var g in Glyphs)
        {
            drawCount++;
            if (drawCount >= MaxDrawCount)
                break; // don't draw more than you want
            if (g.IsEmpty()) continue; // don't draw the blank ones
            // center horizontally in the cell
            double xOffset = (drawCount % ColumnCount) * cellSize.Width + cellSize.Width / 2d - g.Bounds.Width / 2d;
            // place the character on the baseline of the cell
            double yOffset = (drawCount / ColumnCount) * cellSize.Height + fontSize * font.Baseline;
            dc.PushTransform(new TranslateTransform(xOffset, yOffset));
            dc.DrawGeometry(Brushes.Red, null, g);
            dc.Pop(); // get rid of the transform
        }
    }
    int RowCount = drawCount / ColumnCount;
    if (drawCount % ColumnCount != 0) 
        RowCount++; // to include partial rows
    int bitWidth = (int)Math.Ceiling(cellSize.Width * ColumnCount);
    int bitHeight = (int)Math.Ceiling(cellSize.Height * RowCount);
    RenderTargetBitmap bmp = new RenderTargetBitmap(
                                                    bitWidth, bitHeight,
                                                    96, 96,
                                                    PixelFormats.Pbgra32);
    bmp.Render(viz);
    PngBitmapEncoder encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bmp));
    using (FileStream file = new FileStream("FontTable.png", FileMode.Create))
        encoder.Save(file);
