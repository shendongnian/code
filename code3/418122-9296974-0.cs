    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        Session["moviename"] = TextBox3.Text;
        Session["language"] = DropDownList1.Text;
        Response.Redirect("SearchResults.aspx");        
    }
