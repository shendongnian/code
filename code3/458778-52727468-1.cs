    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCompanyName.Text = ddlCompanyName.SelectedValue == "-1" ? string.Empty: ddlCompanyName.SelectedValue; 
        btnCompanyText_Click(this, EventArgs.Empty);
    }
    protected void btnCompanySearch_Click(object sender, EventArgs e)
    {
        Search(false);
        ddlCompanyName.Focus();
    }
    protected void btnCompanyText_Click(object sender, EventArgs e)
    {
        Search(true);
        txtCompanyName.Focus();
    }
    private void Search(bool bVal)
    {
        txtCompanyName.Visible = bVal;
        btnCompanySearch.Visible = bVal;
        btnCompanyText.Visible = !bVal;
        ddlCompanyName.Visible = !bVal;
    }
