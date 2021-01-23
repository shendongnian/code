    namespace MyApp.WebApp
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var db = new MyApp.DataAccess.DB();
                Response.Write(db.cfg);
            }
        }
    }
