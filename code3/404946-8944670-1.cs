    // in the Page_Load
	myRepeater.DataSource = homeItem.GetChildren();
    myRepeater.DataBind();
	
	protected void myRepeater_ItemDataBound(object sender, EventArgs e)
	{
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var scSublayout = e.Item.FindControl("scSublayout") as Sitecore.Web.UI.WebControls.Sublayout;
        if (scSublayout != null)
        {
            scSublayout.Item = (Sitecore.Data.Items.Item)e.Item.DataItem;
        }
      }
	}
