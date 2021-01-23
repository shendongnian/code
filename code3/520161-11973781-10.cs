    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList lvtype = (DropDownList)(DetailsView1.FindControl("DropDownList6"));
        string selectedValue = lvtype.SelectedValue.ToString().ToUpper();
        if (selectedValue == "4 " || selectedValue == "1F")
        {
            SqlDataSource1.SelectParameters["LEAVECODE"].DefaultValue = selectedValue;
       
            lvreason.Visible = true;
        }
    }
