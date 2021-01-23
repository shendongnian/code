    [WebService]
    [ScriptService]
    public class MyWebService : WebService
    {    
      [WebMethod (Description="doc here")]    
      [ScriptMethod(UseHttpGet=false, ResponseFormat=ResponseFormat.Json)]     
      public MyObjectType responseMyObject() 
      {
          Proxy pu = new Proxy(...);
          return pu.GetMyObject();
      }
    }
