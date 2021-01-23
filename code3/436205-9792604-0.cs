        public event EventHandler reset_Popus;
        private void xID_Loaded(object sender, RoutedEventArgs e)
        {
            // I can get the popup relative to the sender
           var stackPanel = (StackPanel)(((Control)sender).Parent);
           var popup = return (Popup)sp.Children[1];
            Action<object,EventArgs> tempEvent = (object a, EventArgs b) =>
            {
                popup.IsOpen = false;
                popup.IsOpen = true;
            };
            reset_Popus += new EventHandler(tempEvent);
            this.LocationChanged += new EventHandler(tempEvent);
      }
      // finally the method that I needed
      public void ResetAllPopups()
      {
          foreach (var d in reset_Popus.GetInvocationList())
          {
              d.DynamicInvoke(null, null);
          }
      }
