    protected void chklst_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList chklst = (CheckBoxList)sender;
        string commandName = chklst.Attributes["CommandName"].ToString();
        string commandArguments = chklst.Attributes["commandArguments"].ToString();
        string dataListRowNumber = chklst.Attributes["DataListRowNumber"].ToString();
    }
