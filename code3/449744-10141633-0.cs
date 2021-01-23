        int width = pictureBox1.Width;
        int height = pictureBox1.Height;
        Bitmap b = new Bitmap(width, height);
        for (int i = 0; i < width; i++)
        {
            int y = (int)((Math.Sin((double)i * 2.0 * Math.PI / width) + 1.0) * (height - 1) / 2.0);
            b.SetPixel(i, y, System.Drawing.Color.Red);
        }
        pictureBox1.Image = b;
