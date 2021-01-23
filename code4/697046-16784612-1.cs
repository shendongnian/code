    protected void LnkBtnRemove_Click(object sender,EventArgs e)
    {
       string id = ((LinkButton)sender).CommandArgument;//CommandArgument is always returns string
       Do_DeleteRow(id);//method to delete
       BindGrid();
    }
    private void Do_DeleteRow(string id)
    {
       //your delete code will be added here
    }
