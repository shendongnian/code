    Rectangle bounds = Screen.GetBounds(Point.Empty);
    Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
    using (Graphics graphics = Graphics.FromImage(bitmap))
    {
        graphics.CopyFromScreen(0, 0, 0, 0, new Size(bounds.Width, bounds.Height));
        using (Image prev_bitmap = pictureBox1.Image)
        {
            pictureBox1.Image = bitmap;
        }
    }
