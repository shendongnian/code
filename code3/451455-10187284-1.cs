    Bitmap bmp;
    ...
    {
     InitializeComponent();
     bmp = new Bitmap(this.Width,this.Height,Graphics.FromHwnd(this.Handle));
    }
    void Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
      Graphics g = Graphics.FromImage(bmp);
      g.DrawLine(0,0,50,50);
      ..
      .. 
      e.Graphics.DrawImage(bmp,0,0);
    }
