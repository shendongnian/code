    Point downPoint;
    void button_MouseDown(object sender, MouseEventArgs e)
    {
      downPoint = e.Location;
    }
    void button_MouseMove(object sender, MouseEventArgs e)
    {    
      if(MouseButtons == MouseButtons.Left){
          Button button = sender as Button;
          button.Left += e.X - downPoint.X;
          button.Top += e.Y - downPoint.Y;
      }
    }
