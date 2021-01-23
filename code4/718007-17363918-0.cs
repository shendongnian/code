    public ICommand addUser 
    {
        get
        {
            if (_addUser == null)
            {
                _addUser = new DelegateCommand(delegate()
                {
                    try
                    {                            
                        Service1Client wcf = new Service1Client();
                        wcf.AddUser(User);
                        Users.Add(User);
                        wcf.Close();
                        this.User = new User();
                    }
                    catch
                    {
                        Trace.WriteLine("working...", "MyApp");
                    }
                });
            }
            return _addUser;
        }
    }
