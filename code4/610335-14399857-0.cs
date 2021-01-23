    void rptMainMenu_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
      var data = e.Item.DataItem as SiteMapNode;
      if (data != null && data.ShowInNavigation) {
        // proceed to populate the repeater item
      } else {
        // do something else
      }
    }
