    using System.Web.Services;
    using System.Web.Script.Serialization;
    
        [System.Web.Script.Services.ScriptService]
        public class YourWebServiceName : System.Web.Services.WebService
        {
            [WebMethod]
            public string yourmethodname(string TheData)
            {
              JavascriptSerializer YourSerializer = new JavascriptSerializer();
              // custom serializer if you need one 
              YourSerializer.RegisterConverters(new JavascriptConverter  [] { new YourCustomConverter() });
    
              //deserialization
              TheData.Deserialize(TheData);
    
              //serialization  
              TheData.Serialize(TheData);
            }
        }
