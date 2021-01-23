    GraphicsPath gfxPath = new GraphicsPath();
    gfxPath.AddLine(line.x1, line.y1, line.x2, line.y2);
    gfxPath.Widen(new Pen(Color.Blue, lineThickness));//lineThinkness is all that matters
    Region reg = new Region(gfxPath);
    if (reg.IsVisible(mousePoint)) // return true if the mousePoint is within the Region.
