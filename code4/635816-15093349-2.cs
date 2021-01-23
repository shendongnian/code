    public class Global : System.Web.HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            // .. read the database here
            HttpContext.Current.Application["SOME_KEY"] = "ANY OBJECT";
            // .. etc
        }
