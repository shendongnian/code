    public void XMLWrite( Dictionary<string, double> dict ) {
       //LINQ to XML
       XDocument doc = new XDocument( new XElement( "calibration" ) );
    
       foreach ( KeyValuePair<string, double> entry in dict )
         doc.Root.Add( new XElement( "ZoomLevel", entry.Value.ToString( ), new XAttribute( "level", entry.Key.ToString( ) ) ) );
    
       doc.Save( pathName );
    }
