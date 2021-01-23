    protected void GetSearchQueryString(object sender, EventArgs e)        
    {
        String s = Request.QueryString["SN"];
        if (s != null && s.Length > 0)
        {            
            Response.Redirect("/AssetManagement.aspx");
        }
    }
    protected void GetSearchSessionVar(object sender, EventArgs e)
    {
            if (Request.QueryString["SN"] != null)
            {
                string sessionVal = Request.QueryString["SN"].ToString();
                AssetSearchTextBox.Text = sessionVal; //setting serial number
                AssetSearchButton_Click(sender, e); //Running asset search
            }            
    }
