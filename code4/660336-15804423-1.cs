    /// <summary>
    /// Gets the Users that are managed by the ClassLogic class
    /// </summary>
    public ObservableList<User> Users
    {
        get { return ClassLogic.Users; }
        //wrong would be:
        //get { return classLogic.Users }
    }
