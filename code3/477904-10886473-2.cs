    public static void Main(string[] args)
    {
        // ...
        #ifdef USER_GUI
        var form = new UserForm()
        #endif
        #ifdef ADMIN_GUI
        var form = new AdminForm()
        #endif
        Application.Run(form);
    }
