    bool ismouseDown = false;
    Point p;
    Graphics g;
    int Xdiff, Ydiff;
    
    public Form1()
    {
        InitializeComponent();
        g = Graphics.FromHwnd(pictureBox1.Handle);          
    }
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
          ismouseDown = true;
          p = e.Location;   
    }
    
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
          if (ismouseDown)
          {
                Xdiff = p.X > e.X?p.X - e.X:e.X - p.X;
                Ydiff = p.Y > e.Y?p.Y - e.Y:e.Y - p.Y;
    
                //this will tell you the radious.
                this.Text = Xdiff.ToString() + " - " + Ydiff.ToString();
                    
                g.FillRectangle(new SolidBrush(pictureBox1.BackColor), pictureBox1.ClientRectangle);
                g.DrawEllipse(Pens.Black,p.X - Xdiff,p.Y - Ydiff, Xdiff * 2, Ydiff * 2);
           }
     }
    
     private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
     {  
           ismouseDown = false;
     }
