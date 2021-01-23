     public partial class formsucker : System.Web.UI.Page
    {
        public String sbG = "";
	
        protected void Page_Init(object sender, EventArgs e)
    	{
                StringBuilder sb = new StringBuilder();	
                sb.Append("<p>" + allYourAppends + "</p>");
                sbG = sb.ToString();
        }
    }
