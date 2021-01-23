    private void ThemeListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count <= 0) //to eliminate IndexOutOfRangeException
        {
            return;
        }
        string selectedItem = e.AddedItems[0] as string;
        switch(selectedItem)
        {
            case "Default":
                //change panorama background here (PanoramaBackground.png)
                (Application.Current as App).YourString = "PanoramaBackground.png";
                break;
            case "Bubbles":
                //change panorama background here (PanoramaBackground_Bubbles.png)
                (Application.Current as App).YourString = "PanoramaBackground_Bubbles.png";
                break;
        }
    }
