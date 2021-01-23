    namespace Helper
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                ServiceReference1.WebService1SoapClient web = new ServiceReference1.WebService1SoapClient();
                web.Method1(5);
                string x = web.Method2(5);
            }
        }
    }
