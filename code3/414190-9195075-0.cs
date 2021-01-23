    private static XDocument _mydoc;
    public static XDocument MyDoc 
    {
       get 
       {
          return _mydoc ?? (_mydoc = XDocument.Parse("WellKnownXmlFile.xml");
       }
    }
