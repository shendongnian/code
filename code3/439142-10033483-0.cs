    /* Be sure to add References to:
     * 
     * umbraco.dll
     * System.Web.dll
     * System.Web.Extensions.dll
     */
    using System.Web;
    using System.Web.Script.Serialization;
    using umbraco.presentation.umbracobase;
    namespace CoB.Umb.Base.Example
    {
        [RestExtension("Example")]
        public class Example
        {
            [RestExtensionMethod(returnXml = false, allowAll = true)]
            public static void Get()
            {
                string json = "";
                var person = new
                {
                    firstName = "John",
                    lastName = "Doe"
                };
                json = new JavaScriptSerializer().Serialize(person);
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(json);
            }
        }
    }
