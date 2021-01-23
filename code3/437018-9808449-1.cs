    protected void rptrUpdates_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       if(e.Item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
       {
          Repeater rptrImages = (Repeater)e.Item.FindControl("rptrImages");
          rptrImages.DataSource = ((Updates)e.Item.DataItem).Images;
          rptrImages.DataBind();
       }
    }
