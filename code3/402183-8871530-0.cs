    bool isChecked;
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ...
        isChecked = ((CheckBox)table.FindControl("chkAll")).Checked;   
    }
