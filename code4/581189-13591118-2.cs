    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Location = new Point(e.X, e.Y);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Location = new Point(e.X + pictureBox1.Left, e.Y + pictureBox1.Top);
    }
