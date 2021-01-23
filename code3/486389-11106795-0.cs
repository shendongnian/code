     private void panel_MouseLeave( object sender, EventArgs e ) {
          Point mouseposition = this.PointToClient( MousePosition ); // to calculate the mouseposition related to the form (keyword this)
          
          //If the mouse isn't into the panel surface...
          if (!(mouseposition.X > panel1.Location.X && mouseposition.Y > panel1.Location.Y && mouseposition.X <  panel.Location.X + panel1.ClientSize.Width  && mouseposition.Y <  panel1.Location.Y + panel.ClientSize.Height) )
              textbox.Clear();
     }
