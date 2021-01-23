    readonly Image _originalImg;
    
    public Form(){
    
        InitializeComponent();
        _originalImg = Image.FromFile("d:\\a.jpg");
    }
    
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    
    private void pictureBox1_paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(_originalImg, 0, 0);
        e.Graphics.DrawString(str, font, color, new PointF( trackBar1.Value, 0));
    }
