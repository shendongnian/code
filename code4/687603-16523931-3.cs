    if (Page.PreviousPage != null && Page.PreviousPage.IsCrossPagePostback) {
      // if you use the PreviousPageDirective you should be able to access the ListView
      // property directly
      // var listView = Page.PreviousPage.MyListView;
      var listView = Page.PreviousPage.FindControl("MyListView") as ListView;
      var linkButton = listView.FindControl("lbtn_naatscat") as LinkButton;
      var submitId = linkButton.CommandArgument;
    }
