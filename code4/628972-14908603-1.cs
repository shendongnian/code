    using System;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Serialization;
    
    [System.Web.Script.Services.ScriptService]
    public class MyWebService: System.Web.Services.WebService 
    {
        [WebMethod]
        public string GetData()
        {
            return "your desired string";
        }
    }
