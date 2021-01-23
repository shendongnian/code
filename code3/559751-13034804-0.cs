    private void map_Held(object sender, HoldingRoutedEventArgs e)        
    {            
        Debug.WriteLine("You held at" + DateTime.Now.ToString() + "" + e.GetPosition(MyMap));            
        var pos = e.GetPosition(MyMap);            
        Location location;            
        MyMap.TryPixelToLocation(pos, out location);                          
        Pushpin pin = new Pushpin();
        pin.Tapped += pushpinTapped;  // <<<<<<=====LOOK AT THIS
        MyMap.Children.Add(pin);                        
        MapLayer.SetPosition(pin, location);                       
    }
