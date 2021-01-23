    class Login
        {
        // [empty containers for newLogin & newPass]
        public static string newLogin { get; set; }
        public static string newPass { get; set; }
    public static void createLogin()
    {           
        // [display new login screen & assign values]
        Console.Clear();
        Console.WriteLine("CREATE NEW LOGIN");
        Console.WriteLine();
        Console.Write("LOGIN: ");
        newLogin = Console.ReadLine();
        Console.Write("PASSWORD: ");            
        newPass = Console.ReadLine();
                  
        // [instantiate & return to main menu]
        //Menu myMenu = new Menu();
        //myMenu.mainMenu();
    } 
   
