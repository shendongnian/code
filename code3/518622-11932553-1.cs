    private Image animGif;// gif animation file
    private void Form1_Load(object sender, EventArgs e)
    {
        animGif = new Bitmap("file.png");
        ImageAnimator.Animate(animGif, Animate);
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        ImageAnimator.UpdateFrames();
        var img = new Bitmap(animGif, animGif.Width, animGif.Height);
        img.MakeTransparent(Color.White);
        e.Graphics.Clear(pictureBox1.BackColor);
        e.Graphics.DrawImage(img, new Point(0, 0));
    }
    private void Animate(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
