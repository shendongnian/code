    private void button1_Click(object sender, EventArgs e)
    {
        var b1 = new Bitmap(BITMAP_NAME);
        var b2 = new Bitmap(b1.Width, b1.Height, PixelFormat.Format8bppIndexed);
        int numColors = b2.Palette.Entries.Length;
        MessageBox.Show(String.Format("Palette contains {0} entries", numColors));
        b2.Dispose();
        b1.Dispose();
    }
