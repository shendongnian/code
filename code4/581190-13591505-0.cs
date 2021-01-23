    private void grid_MouseMove(object sender, MouseEventArgs e)
    { 
          columnPosition = e.X;
    
          if (columnPosition != -1)
          {
              if (!(columnPosition < 35 || columnPosition > 610))
              {
                    PictureBox picBox = chipHolder.Controls[0] // whatever your picbox id is;
                    picBox.Location = new Point(columnPosition - 33, 0);
              }
          }
    }
