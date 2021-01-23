    private void MenuItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       HubTitle tap = (((sender as MenuItem).Parent as ContextMenu).PlacementTarget
                                                                as HubTitle);
    
       //attempt to pass the selected HubTile instance to CreateLiveTiles method
       CreateLiveTile(tap);
    }
