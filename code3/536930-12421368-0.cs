    Response.Redirect("nextpage.aspx?MyItem=somevalue")
    public partial class nextpage: System.Web.UI.Page{
        Item myItem;
        protected void Page_Load(object sender, EventArgs e)
        {
           myItem = Request.QueryString["MyItem"];
           // You can also use Request.Params["MyItem"], but be aware that Params
           // includes both GET parameters (on the query string) and POST paramaters.
        }       
    }
