    public bool ClickOnFirstPixel(Color color)
    {
        var pt = GetFirstPixel(ScreenShot(), color);
        if (pt.HasValue)
        {
            Click(pt.Value);
        }
        // return whether found pixel and clicked it
        return pt.HasValue;
    }
