    public ActionResult YourAction(FormCollection fc)
    {
         foreach (string key in fc.AllKeys)
         {
              string values = fc[key];
              string[] valueArray = values.split(',');
              string value-to-consider = valueArray[0];
              
              //further processing.
         }
         
    }
