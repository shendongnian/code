    private void timeShoot_Tick(object sender, EventArgs e)
      {
        if (control == false)
        {   
           foreach PictureBox shot in ListShot
           {
               shot.Location = new Point(spacecraft._imageBox.Location.X + 50, spacecraft._imageBox.Location.Y - 55);  // align the shoot with spacecraft
               shot.Top -= 40;
           }
           control = true;
        }
      }
