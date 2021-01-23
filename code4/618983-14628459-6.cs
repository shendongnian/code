    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
 
        }
 
        [WebMethod]
        public static string TestService(string id) 
        {
            var string = DBCollection.FirstOrDefault(x => x.id == id); // Or whatever you want to return the data
            return "You called me on " + DateTime.Now.ToString() + "with " + string;
        }
    }
