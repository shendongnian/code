    using System;
    using System.Web.Script.Services;
    using System.Web.Services;
    [WebService(Namespace = "http://url.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class MyWebService : WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] // or ResponseFormat.Xml
        public ResponseObject MyWebMethod(RequestObject input)
        {
            ResponseObject response = new ResponseObject();
            // Do some stuff
            return response;
        }
    }
