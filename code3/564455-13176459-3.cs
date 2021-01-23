    FileInfo kmlFile = new FileInfo("5603.kml");
    
    String kmlString = "";
    using (StreamReader sr = new StreamReader(kmlFile.OpenRead()))
    {
        kmlString = sr.ReadToEnd();
    }
    
    Kml kml = new Kml(kmlString);
    String country = kml.GetCountryByCoordinates(18.26, 42.56);
