    private void ChangeColor(Bitmap s, System.Drawing.Color source, System.Drawing.Color target)
    {
        for (int x = 0; x < s.Width; x++)
        {
            for (int y = 0; y < s.Height; y++)
            {
                if (s.GetPixel(x, y) == source)
                    s.SetPixel(x, y, target);
            }                
        }
    }
