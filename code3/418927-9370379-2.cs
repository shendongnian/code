     protected void DViewComputer_DataBound1(object sender, EventArgs e)
    {
        int noRow = DViewComputer.Rows.Count - 1;//get the no of record
        if (!IsPostBack)
        {
            Button button = (Button)(DViewComputer.Rows[noRow].Cells[0].Controls[2]);
            // Add delete confirmation
            ((System.Web.UI.WebControls.Button)(button)).OnClientClick = "if (!confirm('Are you sure " +
                                   "you want to delete this record?')) return;";
        }
    }
