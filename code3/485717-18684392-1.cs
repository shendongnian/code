    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public WebService()
        {
        }
    
        [WebMethod]
        public void HelloWorld() // It's IMP to keep return type void.
        {
            string strResult = "Hello World";
            object objResultD = new { d = strResult }; // To make result similarly like ASP.Net Web Service in JSON form. You can skip if it's not needed in this form.
    
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            string strResponse = ser.Serialize(objResultD);
    
            string strCallback = Context.Request.QueryString["callback"]; // Get callback method name. e.g. jQuery17019982320107502116_1378635607531
            strResponse = strCallback + "(" + strResponse + ")"; // e.g. jQuery17019982320107502116_1378635607531(....)
    
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.AddHeader("content-length", strResponse.Length.ToString());
            Context.Response.Flush();
    
            Context.Response.Write(strResponse);
        }
    }
