    public Form(){
    
        InitializeComponent();
        pictureBox1.Image = Image.FromFile("d:\\a.jpg");
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
    }
    
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    
    private void pictureBox1_paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawString(str, font, color, new PointF( trackBar1.Value, 0));
    }
