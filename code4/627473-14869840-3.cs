    protected void GridViewRowCommand(Object sender, GridViewCommandEventArgs e)
    {
        var scrapId = Int32.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "like" : 
                    using (var con = new SqlConnection("connection_string")) //your connection string
                    {
                       var cmd = new SqlCommand("insert into tbl_like (ScrapId,FromId,LikeStatus) values(@scrapId,@sessionUser,1)");
                       cmd.Parameters.AddWithValue("@scrapId", scrapId);
                       cmd.Parameters.AddWithValue("@sessionUser", Session[User]); 
                       cmd.Connection = con;
                       con.Open();
                       cmd.ExecuteNonQuery();
                    }
                    break;
            case "unlike" : 
                    //do stuff
                    break;
        }
    }
