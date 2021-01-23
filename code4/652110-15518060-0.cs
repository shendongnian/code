    public Mainform(User user)
    {
       InitializeComponent();
       if(user.UserType == UserType.User)
       {
          // Make your buttons invisible
          buttonOnlyForAdmins.Visible = false;
       }
    }
    
