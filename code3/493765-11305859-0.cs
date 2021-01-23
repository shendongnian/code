    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class EmailSender : System.Web.Services.WebService
    {
        [WebMethod]
        public void SendEmail(string email, string message)
        {
            //Send my email
        }
    }
