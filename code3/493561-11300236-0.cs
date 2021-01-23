    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        var hPadding = (pictureBox1.Width - pictureBox1.BackgroundImage.Width) / 2;
        var vPadding = (pictureBox1.Height - pictureBox1.BackgroundImage.Height) / 2;
        var imgRect = new Rectangle(pictureBox1.Left + hPadding, pictureBox1.Top + vPadding, pictureBox1.BackgroundImage.Width, pictureBox1.BackgroundImage.Height);
        e.Graphics.DrawImage(pictureBox1.BackgroundImage, imgRect);
    }
