    private bool BitmapChanged(Bitmap old, Bitmap new)
    {
        return old == null || old.PixelFormat != new.PixelFormat ||
            old.Width != new.Width || old.Height != new.Height;
    }
    private Bitmap MakeSimilarBitmap(Bitmap source)
    {
        Bitmap copy = new Bitmap(source.Width, source.Height, source.PixelFormat);
        return copy;
    }
    private void DrawOnto(Image im, Bitmap source)
    {
        using (Graphics g = Graphics.FromImage(im)) {
            g.DrawImage(source, 0, 0);
        }
    }
