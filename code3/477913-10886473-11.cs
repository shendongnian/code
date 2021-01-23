    public static void Main(string[] args)
    {
        // ...
        #if USER_GUI
        var form = new UserForm()
        #endif
        #if ADMIN_GUI
        var form = new AdvancedForm()
        #endif
        Application.Run(form);
    }
