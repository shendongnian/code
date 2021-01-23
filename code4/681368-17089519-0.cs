        public partial class Bla zay blaz : System.Web.UI.Page
    {
        string BaseUrl = "/blahblah.aspx?";
        string op;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                op = Server.HtmlDecode(Request.QueryString["op"]);
                if (op == null)
                    op = "A";
                RadioButtonList1.SelectedValue = op;
	}
        protected void RadioButtonChanged(object sender, EventArgs e)
        {
            op = RadioButtonList1.SelectedValue;
            if (op == null)
                op = "NC";
            if (op != "A")
                BaseUrl += "Op=" + op + "&";
	Response.Redirect(string.Format(BaseUrl, Server.HtmlEncode(op));
	}
    }
