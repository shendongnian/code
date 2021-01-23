    public class FlightInfo
    {
      public string FormID {get;set;}
      public string GateLetter {get;set;}
      //... 
      public string objectId {get;set;}
    }
    
    public class FlightContainer
    {
        public List<FlightInfo> results;
    }
    JavaScriptSerializer js = new JavaScriptSerializer();
    var deserializedObject = js.Deserialize<FlightContainer>(yourJsonString);
