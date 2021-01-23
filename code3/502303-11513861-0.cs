    private void DestinationButton_Click(object sender, RoutedEventArgs e) 
    { 
       string[] doubles = this.Coordinates.Text.Split(',');
       var xCoord = double.Parse(doubles[0], System.Globalization.CultureInfo.InvariantCulture);
       var yCoord = double.Parse(doubles[1], System.Globalization.CultureInfo.InvariantCulture);
       Location loc= new Location (xCoord,yCoord); 
       myMap.Center = loc; 
       myMap.ZoomLevel = 8; 
    } 
