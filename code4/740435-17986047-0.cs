      private Point p;
      private void Form1_MouseDown(object sender, MouseEventArgs e)
      {
         p = new Point(e.X, e.Y);
      }
      private void Form1_MouseUp(object sender, MouseEventArgs e)
      {
         int distance = e.Y - p.Y;
         // so the window won't move with every click
         if (distance > 10)
         {
            Location = new Point(Location.X, Location.Y + distance);
         }
      }
