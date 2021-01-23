    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    int noRow=DViewCompDetail.Rows.Count - 1;//get the no of row
    if (!IsPostBack)
        {
            Button button = (Button)(DViewComputer.Rows[noRow].Cells[0].Controls[2]);
            // Add delete confirmation
            ((System.Web.UI.WebControls.Button)(button)).OnClientClick = "if
            (!confirm('Are you sure " +"you want to delete this record?')) return;";
        }
    }
