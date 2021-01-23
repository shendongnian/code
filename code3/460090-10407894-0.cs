    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("I CAN ONLY SEE THIS NO OTHER HTML TAG IS INCLUDED");
            Response.End();
        }
    }
