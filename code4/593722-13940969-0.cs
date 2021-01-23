     private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
          // Check if Key.Space pressed
          if(SpacePressed) {
               // Do something
          }
     }
     private void KeyPressed_Event(object sender, KeyEventArgs e) {
          // Check if Key.Space pressed
          if(e.Key == Key.Space) {
               SpacePressed = true;
          }
     }
     private void KeyRelease_Event(object sender, KeyEventArgs e) {
          // Check if Key.Space pressed
          if(e.Key == Key.Space) {
               SpacePressed = false;
          }
     }
