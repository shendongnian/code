    protected void HandleGridItemCreated(object sender, GridItemEventArgs e)
    {
     if(e.Item is GridCommandItem)
     {
      var button = e.Item.FindControl("SaveChangesIcon") as Button;
      var link = e.Item.FindControl("SaveChangesButton") as LinkButton;
      button.Text += "<span class='red'>*</span>";
     }
    }
