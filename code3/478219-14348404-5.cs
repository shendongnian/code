Code
    private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (((Panorama)sender).SelectedIndex)
        {
            case 0: // defines the first PanoramaItem
                ApplicationBar.IsVisible = true;
                break;
            case 1: // second one
                ApplicationBar.IsVisible = false;
                break;
            case 2: // third one
                ApplicationBar.IsVisible = true;
                break;
        }
    }
