    public partial class WebForm2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            object obj = this.Context.Application["SOME_KEY"];
            // ...etc...
        }
    }
