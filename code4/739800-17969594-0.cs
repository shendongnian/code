    protected void ddltext_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPerc.SelectedValue.Equals("0.01"))
        {
            txtbox.Enabled = false;
        }
    }
