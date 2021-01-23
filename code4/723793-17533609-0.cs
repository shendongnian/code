    [HttpPost]
    public ActionResult Index(FormCollection formCollection)
    {
      foreach (string extendedProperty in formCollection)
      {
         if (extendedProperty.Contains("Property-"))
         {
           string extendedPropertyValue = formCollection[extendedProperty];
         }
      }
 
      ...
    }
