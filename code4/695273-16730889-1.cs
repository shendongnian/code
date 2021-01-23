    public string Login
    {
        get { return _TModel.Login; }
        set
        {
            if (value == _TModel.Login)
                return;
            value = string.Empty;
            _TModel.Login = value + "@" + IpAddress;
            base.OnPropertyChanged("Login");
        }
    }
