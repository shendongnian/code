     protected void rptCategory_ItemCreated(object sender, RepeaterItemEventArgs e)
     {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ScriptManager1.RegisterAsyncPostBackControl(e.Item.FindControl("lnkCategory"));
                }
      }
