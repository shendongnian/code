    Rectangle bounds = Screen.GetBounds(Point.Empty);
    Image bitmap = pictureBox1.Image ?? new Bitmap(bounds.Width, bounds.Height);
    
    using (Graphics graphics = Graphics.FromImage(bitmap))
    {
        graphics.CopyFromScreen(0, 0, 0, 0, new Size(bounds.Width, bounds.Height));
        if (pictureBox1.Image == null)
        {
            pictureBox1.Image = bitmap;
        }
        else
        {
            pictureBox1.Refresh();
        }
    }
