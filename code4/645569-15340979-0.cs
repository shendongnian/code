    public void GetSearchString()
    {
        Data.Database.FRCDatabaseDatacontext context = new Data.Database.FRCDatabaseDatacontext();
        lstName.ItemsSource = (from s in context.GetSearchProcedure(txtName.Text) 
                      where s.UserGuid == Workspace.Instance.ActiveUser.CurrentUserActiveDirectoryGuid
                      select s).ToList();
    }
