    public HomeController()
    {   
        Model1Container db = new Model1Container();
        this.userRepository = new UserRepository(db);
    }
