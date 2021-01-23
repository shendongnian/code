    public partial class SampleForm : System.Web.UI.Page
    {
        [WebMethod]
        public static string SendMessage(string message)
        {
            return message;
        }
    }
