    //assuming that this code is within the parent Form
    
    private void timer1_Tick(object sender, EventArgs e)
    {
      this.SuspendLayout();
      picust.Location = new Point(picust.Location.X, picust.Location.Y + 10);
      picx.Location = new Point(picx.Location.X, picx.Location.Y + 10);
      picy.Location = new Point(picy.Location.X, picx.Location.Y + 10);
      this.ResumeLayout();
    }
