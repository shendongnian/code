    GridView1.RowCommand += (o, e) =>
        {
            var row = (e.CommandSource as Button).NamingContainer as GridViewRow;
            var makeComments = row.FindControl("MakeComments") as TextBox;
            int scrapId = Int32.TryParse((string)e.CommandArgument, out scrapId) ? scrapId : 0;
            var gridView2 = row.FindControl("GridView2") as GridView;
    
            ... place here the code which the comments
    
            gridView2.DataSource = GetCommentsByScrapId();
            gridView2.DataBind();
        };
