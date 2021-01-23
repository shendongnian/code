     private void panoramaMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
     {
        Panorama p = (Panorama) sender;
        if(p.SelectedIndex == 1) {
           messageList.Margin = new Thickness(0, 0, 0, ApplicationBar.DefaultSize);
           ApplicationBar.IsVisible = true;
        } else {
           messageList.Margin = new Thickness(0, 0, 0, 0);
           ApplicationBar.IsVisible = false;
        }
     }
