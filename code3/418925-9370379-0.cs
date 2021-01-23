    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (!IsPostBack)
        {
            Button button = (Button)(DViewComputer.Rows[30].Cells[0].Controls[2]);
            // Add delete confirmation
            ((System.Web.UI.WebControls.Button)(button)).OnClientClick = "if
            (!confirm('Are you sure " +"you want to delete this record?')) return;";
        }
    }
