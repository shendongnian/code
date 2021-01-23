    bool inside = false;
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
         if (e.Y > 10 && e.Y < 2 * e.X - 10 && e.Y < -2 * e.X + 110)
         {
              if (!inside)
              {
                   inside = true;
                   HandleMouseEnter();
              }
         }
         else
              inside = false;
     }
     void HandleMouseEnter()
     {
           MessageBox.Show("Mouse inside");
     }
