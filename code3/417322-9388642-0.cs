     private void HandleAppHookMouseMove(object sender, MouseEventArgs e)
     {
     
            if (this.Bounds.Contains(e.Location))
            {
                  HandleEnter();
            }
            else
            {
                  HandleLeave();
            }          
      }
