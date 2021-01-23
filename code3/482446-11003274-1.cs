    class SomeClass
    {
         DiceRoller dr;
    
        public SomeClass()
        {
            DiceRoller dr = new DiceRoller();
        }  
    
        public void CreateInput()
        {
                Console.Clear();
                Console.WriteLine("  _, __, __,  _, ___ __,    _, _,_  _, __,  _,  _, ___ __, __,");
                Console.WriteLine(" / ` |_) |_  /_\\  |  |_    / ` |_| /_\\ |_) /_\\ / `  |  |_  |_)");
                Console.WriteLine(" \\ , | \\ |   | |  |  |     \\ , | | | | | \\ | | \\ ,  |  |   | \\");
                Console.WriteLine("  ~  ~ ~ ~~~ ~ ~  ~  ~~~    ~  ~ ~ ~ ~ ~ ~ ~ ~  ~   ~  ~~~ ~ ~");
                Console.WriteLine("<==============================================================>");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Player Name: ");
                Console.ReadLine();
                Console.Write("Select Race: ");
                Console.ReadLine();
                Console.Write("Select Class: ");
                Console.ReadLine();
                Console.WriteLine("Stats: ");
                Console.Write("STR: ");
                Console.Write(dr.getDiceRoll());
                Console.ReadLine();
         }
    }
