    protected void sidebarListView_ItemDataBound ( object sender , ListViewItemEventArgs e ) {
      LinkButton button = e.Item.FindControl( "NameLabel" ) as LinkButton;
      if (FacultyName != null && button != null) {
         if ( button.Text == FacultyName ) {
            button.CssClass = "sidebarItemActive";
         }
      }
