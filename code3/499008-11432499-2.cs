    private string CleanJavaScriptString( string stringToClean )
    {
      System.Web.Script.Serialization.JavaScriptSerializer serializer = new 
        System.Web.Script.Serialization.JavaScriptSerializer();
      return serializer.Serialize(stringToClean);
    }
