    public string SelectedValue
    {
        get
        {
            return ddlcategories.SelectedValue;
        }
        set
        {
            ddlcategories.SelectedValue= value;
        }
    }
    protected void ddlcategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedValue = ddlcategories.SelectedValue;
    }
