    public class ApplicationContext
    {
            // Static instance of the application class.
            private static ApplicationContext _instance;
    
            public static ApplicationContext Instance()
            {
                return _instance ?? (_instance = new ApplicationContext()
            }
    
            public UserDetailsCustomClass SecurityContext { get; set; }
    }
