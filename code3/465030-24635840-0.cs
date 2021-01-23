    public ActionResult YourAction(FormCollection fc)
    {
         foreach (string key in fc.AllKeys)
         {
              string value-to-consider = fc.GetValues(key).FirstOrDefault();
    
              //further processing.
         }
    
    }
