    static void Main(string[] args) 
    { 
         bool userIsAuthenticated = MyClass.AuthenticateUser();
         if (userIsAuthenticated)
             MyClass.MyMethod(); 
     } 
