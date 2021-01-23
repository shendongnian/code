    private bool clicked = false;
    private Point lmAbs = new Point();
    void PnMouseDown(object sender, System.Windows.Input.MouseEventArgs e)
    {
      clicked = true;
      this.lmAbs = e.GetPosition(this);
      this.lmAbs.Y = Convert.ToInt16(this.Top) + this.lmAbs.Y;
      this.lmAbs.X = Convert.ToInt16(this.Left) + this.lmAbs.X;
    }
    void PnMouseUp(object sender, System.Windows.Input.MouseEventArgs e)
    {
      clicked = false;
    }
  
    void PnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
      if (clicked)
      {
        Point MousePosition = e.GetPosition(this);
        Point MousePositionAbs = new Point();
        MousePositionAbs.X = Convert.ToInt16(this.Left) + MousePosition.X;
        MousePositionAbs.Y = Convert.ToInt16(this.Top) + MousePosition.Y;
        this.Left = this.Left + (MousePositionAbs.X - this.lmAbs.X);
        this.Top = this.Top + (MousePositionAbs.Y - this.lmAbs.Y);
        this.lmAbs = MousePositionAbs;
      }
    }
