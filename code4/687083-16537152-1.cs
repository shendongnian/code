    protected void postLikeInsert_DataBound(object sender, EventArgs e)
        {
            DetailsView d = (DetailsView)sender;
            GridViewRow row = (GridViewRow)d.NamingContainer;
            int idx = row.RowIndex;
            GridView grid = (GridView)row.NamingContainer;
            string strGoalIndicatorID = grid.DataKeys[idx]["id"].ToString();
            LinkButton b = (LinkButton)d.FindControl("Like");
            b.CommandArgument = strGoalIndicatorID;
        }
        protected void postLikeInsert_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                DetailsView d = (DetailsView)sender;
                d.ChangeMode(DetailsViewMode.Insert);
                ObjectDataSource o = (ObjectDataSource)d.NamingContainer.FindControl("odsPostLikes");
                o.InsertParameters["postId"].DefaultValue = e.CommandArgument.ToString();
            }
        }
