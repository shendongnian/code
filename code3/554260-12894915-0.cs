    var bitmap = new Bitmap(width, height, width, PixelFormat.Format8bppIndexed);
    ColorPalette palette = bitmap.Palette;
    palette.Entries[0] = Color.Black;
    for (int i = 1; i < 256; i++)
    {
        // set to whatever colour here...
        palette.Entries[i] = Color.FromArgb((i * 7) % 256, (i * 7) % 256, 255);
    }
    bitmap.Palette = palette;
