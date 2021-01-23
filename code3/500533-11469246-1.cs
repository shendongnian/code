    class MainProg
    {
    
        static void Main()
        {
            Register rs = new Register();
            Register r = (Register)rs;
    
            r.run();
            Console.WriteLine(r.name);
        }
    
    }
    
    
    class Register : MainProg
    {
        public string name;
        public void run()
         {
            name = "a";
         }
    }
