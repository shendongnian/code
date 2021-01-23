        protected void MySponsoredChildrenList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewProfile")
            {
                int childId = 0;
                var hiddenField = e.Item.FindControl("ChildID") as HiddenField;
                if (null != hiddenField)
                {
                    if (!string.IsNullOrEmpty(hiddenField.Value))
                    {
                        childId = Convert.ToInt32(hiddenField.Value);
                    }
                }
                if (childId > 0)
                {
                    Response.Redirect("~/ChildDescription.aspx?ID=" + childId);
                }
            }
        }
