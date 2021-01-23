    private void BindGridView()
    { 
            // place your bind grid code here..
        DBConnection db = new DBConnection();
        
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow gvrow = GridView1.Rows[i];
            ImageButton ib = (ImageButton)gvrow.Controls[1].Controls[0];
            string feedUrl = ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value;
            bool res = db.CheckAddedFeeds(feedUrl, User_Name);
            if (res)
            {
                ib.ImageUrl = "~/images/delete.png";
            }
        }
    }
