        protected void MySponsoredChildrenList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewProfile")
            {
                int ChildIDQuery = Convert.ToInt32(e.Item.FindControl("ChildID"));
                Response.Redirect("~/ChildDescription.aspx?ID=" + ChildIDQuery);
            }
        }
