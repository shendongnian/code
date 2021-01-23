    private Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(sourceBMP, 0, 0, width, height);
        }
        return result;
    }
