    protected void rptDynamicForm_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
       switch (e.Item.ItemType) {
    	   case ListItemType.Item:
    	   case ListItemType.AlternatingItem:
    	      if (e.Item.ItemIndex != 0) {
                 DropDownList toParentDDL = 
                    (DropDownList)rptDynamicForm.Items[e.Item.ItemIndex - 1].FindControl("ParentControlID");
    	      }
    	      break;
    	}
    }
