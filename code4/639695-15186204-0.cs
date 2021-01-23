    public void paint(object sender, PaintEventArgs e)
    {
      base.OnPaint(e);
    
      Graphics g = e.Graphics;       
      g.Clear(Color.PaleVioletRed);
    
      // skip drawing if cond is true (condition is not relevant)
      if(!cond)
      {
        // l is some List<p>
        foreach(Point p in l)
        { 
          // ...calculate X and Y... (not relevant)  
          g.FillEllipse(new SolidBrush(Color.Blue), p.X,p.Y, Point.SIZE,Point.SIZE);
        }                                          
      }
    }
