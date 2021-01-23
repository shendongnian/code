    private void pictureBox1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      DrawCar1(e.Graphics);
      DrawCar2(e.Graphics);
    }
    public void DrawCar1(Graphics g)
    {
      g.DrawEllipse(pen1, 50, 125, 30, 30);
      g.DrawEllipse(pen1, 150, 125, 30, 30);
      // etc.
    }
    public void DrawCar2(Graphics g)
    {
      // etc.
    }
