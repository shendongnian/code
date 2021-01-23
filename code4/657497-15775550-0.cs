    public override void Uninstall(System.Collections.IDictionary stateSaver)
    {
        string userName = this.Context.Parameters["UserName"];
        if (userName == null)
        {
            throw new InstallException("Missing parameter 'UserName'");
        }
    
        string password = this.Context.Parameters["Password"];
        if (password == null)
        {
            throw new InstallException("Missing parameter 'Password'");
        }
    
        _process = new ServiceProcessInstaller();
        _process.Account = ServiceAccount.User;
        _process.Username = userName;
        _process.Password = password;
        _service = new ServiceInstaller();
        _service.ServiceName = _serviceName;
        _service.Description = "My service description";
        _service.StartType = ServiceStartMode.Automatic;
        Installers.Add(_process);
        Installers.Add(_service);
    
        base.Uninstall(stateSaver);
    }
