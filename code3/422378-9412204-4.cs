    byte[] input = new byte[] { 0x00, 0x00, 0x30, 0x00, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x30, 0x00, 0x00, 0x00 };
    glyph = new Bitmap(16, 14, System.Drawing.Imaging.Format1bppIndexed);
    for(int y = 0; y < glyph.Height; y++)
    {
      int input_y = (glyph.Height - 1) - y; // Flip it right side up.
      for(int x = 0; x < glyph.Width; x++)
      {
        bool on = input[2 * input_y + x / 8] & (0x80 >> (x % 8));
        glyph.SetPixel(x, y, on ? System.Drawing.Color.Black : System.Drawing.Color.White);
      }
    }
