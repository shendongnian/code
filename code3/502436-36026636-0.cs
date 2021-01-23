    public class Test
        {
                public Test()
                { }
    
            public static void Main(string[] args)
            {
                int i = 0;
    
                Console.WriteLine("\n" + "Displaying Initial            i      =     " + i + "\n");   // Prints 0 i.e. Initial value of i
    
                Console.WriteLine("\n" + "Displaying PostFix            i++    =     " + i++ + "\n"); // Prints 0. Then value of i becomes 1.
    
                Console.WriteLine("\n" + "Displaying Post-incremented   i      =     " + i + "\n");   // Prints 1 i.e. Value of i after Post-increment
    
                Console.WriteLine("\n" + "Displaying PreFix             ++i    =     " + ++i + "\n"); // Prints 2. Then value of i incremented to 2
    
                Console.WriteLine("\n" + "Displaying Pre-incremented    i      =     " + i + "\n");   // Prints 2 i.e. Value of i after Pre-increment
    
                Console.WriteLine("\n" + "---------------------------------------------" + "\n");
    
                int j = 0;
    
                Console.WriteLine("\n" + "Displaying Initial            j      =     " + j + "\n");   // Prints 0 i.e. Initial value of j
    
                Console.WriteLine("\n" + "Displaying PreFix             ++j    =     " + ++j + "\n"); // Prints 1. Then value of j incremented to 1.
    
                Console.WriteLine("\n" + "Displaying Pre-incremented    j      =     " + j + "\n");   // Prints 1 i.e. Value of j after Pre-increment
    
                Console.WriteLine("\n" + "Displaying PostFix            j++    =     " + j++ + "\n"); // Prints 1. Then value of j incremented to 2.
    
                Console.WriteLine("\n" + "Displaying Post-incremented   j      =     " + j + "\n");   // Prints 2 i.e. Value of j after Post-increment
                            
                Console.ReadLine();
            }
        }
