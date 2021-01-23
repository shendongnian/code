    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> x = new List<int>() { 76, -66, 646, -76, -10, -6, 16, 676 };
            this.GridView1.DataSource = x;
            this.GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(e.Row.Cells[0].Text) < 0)
                {
                    e.Row.Cells[0].Text = "(" + e.Row.Cells[0].Text + ")";
                }
            }
    
        }
    }
