    private bool FindBitmap(Bitmap BmpNeedle, Bitmap BmpHaystack, out Point location)
    {
        int countTimesFound = 0;
        for (int outerX = 0; outerX < BmpHaystack.Width - BmpNeedle.Width; outerX++)
        {
            for (int outerY = 0; outerY < BmpHaystack.Height - BmpNeedle.Height; outerY++)
            {
                for (int innerX = 0; innerX < BmpNeedle.Width; innerX++)
                {
                    for (int innerY = 0; innerY < BmpNeedle.Height; innerY++)
                    {
                        Color cNeedle = BmpNeedle.GetPixel(innerX, innerY);
                        Color cHaystack = BmpHaystack.GetPixel(innerX + outerX, innerY + outerY);
                        if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                        {
                            continue;
                        }
                    }
                }
                countTimesFound++;
                if (countTimesFound == 2)
                {
                    location = new Point(outerX, outerY);
                    return true;
                }
            }
        }
        location = Point.Empty;
        return false;
    }
