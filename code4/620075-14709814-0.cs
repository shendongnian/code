    public DelegateCommand SaveAuthorizationCommand
    {
        get
        {
            return saveAuthorizationCommand ??
                   saveAuthorizationCommand = new DelegateCommand(SaveAuthorization, CanSaveAuthorization);
        }
    }
