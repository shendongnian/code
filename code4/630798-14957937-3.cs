    Bitmap bmp1 = new Bitmap(2480, 3508);
    panel1.DrawToBitmap(bmp1, new Rectangle(0, 0, 2480, 3508));
    Image img = pictureBox1.Image;
    pictureBox1.Image = bmp1;
    if (img != null) img.Dispose(); // the first time it'll be null
