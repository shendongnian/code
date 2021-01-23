    public void lbtn1_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string userID = lbtn.CommandArgument;
        string dropDownValue = myDropDown.SelectedValue;
        string navigateUrl = string.Format("Edit.aspx?userid={0}&dropdown={1}", 
            userID, dropDownValue);
        Response.Redirect(navigateUrl);
    }
