    Bitmap bmp = new Bitmap(gImg2.Width, gImg2.Height);
    using (Graphics g = Graphics.FromImage(bmp))
    {
    	g.DrawImage(gImg2, 0, 0, new Rectangle(e.SplitX, 0, gImg2.Width - e.SplitX,   gImg2.Height), GraphicsUnit.Pixel);
    }
    pictureBox2.Image = bmp;
