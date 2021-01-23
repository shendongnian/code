    private void map_Held(object sender, HoldingRoutedEventArgs e)        
    {            
        Debug.WriteLine("You held at" + DateTime.Now.ToString() + "" + e.GetPosition(MyMap));            
        var pos = e.GetPosition(MyMap);            
        Location location;            
        MyMap.TryPixelToLocation(pos, out location);                          
        Pushpin newpin = new Pushpin();            
        newpin.Tapped += pushpin_Tapped;
        MyMap.Children.Add(newpin);                        
        MapLayer.SetPosition(newpin, location);                       
    }
