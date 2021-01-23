    ColorPalette palette = originalBitmap.Palette;
    Color first = palette.Entries[0];
    for (int i = 0; i < (palette.Entries.Length - 1); i++)
    {
        palette.Entries[i] = palette.Entries[i + 1];
    }
    palette.Entries[(palette.Entries.Length - 1)] = first;
    originalBitmap.Palette = palette;
