    public UserController(IUserView view)
    {
        _view = view;
        _view.Create += ViewOnSave;
    }
    private void ViewOnSave(User model)
    {
        SqlConnection connection = new SqlConnection(connString);
        connection.Open();
        //... save query goes here
    }
