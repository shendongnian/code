     private void bottomappbar_opened_event(object sender, object e)
     {
         if (!this.BottomAppBar.IsEnabled)
         {
             if (this.BottomAppBar.IsOpen)
             this.BottomAppBar.IsOpen = false;
         }
     }
