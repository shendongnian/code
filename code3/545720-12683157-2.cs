        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [ScriptService] ///******************* Important
        public class BookWebService : System.Web.Services.WebService
        {
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)] ///******************* Important
            public string list()
            {
              return "Hi";
              
            }
         }
