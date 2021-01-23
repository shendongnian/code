    private int[] ParseBusyPlace(string xml)
           {
               var busyPlaces = from element in XDocument.Parse(xml).Descendants("Place")
                                select (int) element.Attribute("ID");
    
               return busyPlaces.ToArray(); 
    
           }
