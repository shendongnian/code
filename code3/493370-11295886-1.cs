    Bitmap bitmap = new Bitmap(panel1.Size.Width, panel1.Size.Height);
    using (Graphics g = Graphics.FromImage(bitmap))
    {
        g.DrawImage(pictureBox1.BackgroundImage, new Rectangle(pictureBox1.Location, pictureBox1.Size));
        g.DrawImage(pictureBox2.BackgroundImage, new Rectangle(pictureBox2.Location, pictureBox2.Size));
        g.Flush();
    }
    
    pictureBox1.Visible = false;
    pictureBox2.Visible = false;
    panel1.BackgroundImage = bitmap;
