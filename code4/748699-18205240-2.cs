    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        Bitmap b = new Bitmap(pictureBox1.Image);
        Color color = b.GetPixel(e.X, e.Y);
        if (color.A != 0)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
        }
    }
    private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
    {
        Bitmap b = new Bitmap(pictureBox1.Image);
        Color color = b.GetPixel(e.X, e.Y);
        if (color.A == 0)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }
    }
