    private void Form3_Load(object sender, EventArgs e)
    {
      MouseDetector m = new MouseDetector();
      m.MouseMove += new MouseDetector.MouseMoveDLG(m_MouseMove);
    }
    void m_MouseMove(object sender, Point p)
    {
      Point pt = this.PointToClient(p);
      this.Text = (this.ClientSize.Width >= pt.X && 
                   this.ClientSize.Height >= pt.Y && 
                   pt.X > 0 && pt.Y > 0)?"In":"Out";     
    }
