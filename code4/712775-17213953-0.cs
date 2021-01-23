    protected void gridContractor_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        [...]
        GridViewRow selectedRow = (GridViewRow((Button)e.CommandSource).NamingContainer;
        int intRowIndex = Convert.ToInt32(selectedRow.RowIndex);
        gridContractor.SelectedIndex = intRowIndex 
        [...]
    }
