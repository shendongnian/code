    protected void ListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
      {
        if (String.Equals(e.CommandName, "OpenPopup"))
        {
          
          ListViewDataItem dataItem = (ListViewDataItem)e.Item;
          Session["UserID"]=((Label)dataItem.FindControl("Label6")).Text;
          Session["SearchUser"] = txtBenutzer.Text;                     
          Session["DropDownValue"] = dropWerk.SelectedValue;
          Page.ClientScript.RegisterStartupScript(GetType(), "Key", "OpenPopupFunction();", true); 
          
        }     
    }
