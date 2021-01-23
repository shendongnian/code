    public partial class WebForm2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SomeRecord[] records = Helper.SomeRecords;
            // ...etc...
        }
    }
