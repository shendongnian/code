    public void GetSearchString()
      {
          var context = new Data.Database.FRCDatabaseDatacontext();
          var result = context.GetSearchProcedure(txtName.Text);
          var itemSource = result.ToList();
            foreach (GetSearchProcedureResult search in itemSource)
            if (search.UserGuid == Workspace.Instance.ActiveUser.CurrentUserActiveDirectoryGuid)
            {
                lstName.ItemsSource = itemSource;
            }
        }
