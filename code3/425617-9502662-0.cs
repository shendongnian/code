    public partial class _Default : System.Web.UI.Page
    {
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (SomeCondition(x, y))
            {
                ViewState["foo"] = "apple";
                ViewState["bar"] = "orange";
            }
        }
    
        protected void ShowFooBar_Click(object sender, EventArgs e)
        {
            Response.Write("foo=" + ViewState["foo"].ToString() + "& bar=" + ViewState["bar"].ToString());
        }
    }
