    static void Main(string[] args)
            {   //here we declare the variables and the 2 arrays for the main method
    
                int perfecto = 100;
                string input;
                string student = string.Empty;
                int score = 0;            
    
    
                //this will be the introduction for the program nice and friendly.
                Console.WriteLine("Welcome to the Test score calculator!!");
                Console.Write("\nPlease Input your name and your score, seperated by a space and Press Enter, insert END if you want to finish: ");
    
                while (!(input = Console.ReadLine()).Equals("end", StringComparison.CurrentCultureIgnoreCase))
                {
                    SplitMethod(input, ref student, ref score);
                    Output(student, score, perfecto);
                    Console.Write("\nPlease Input your name and your score, seperated by a space and Press Enter, insert END if you want to finish: ");
                }
                Console.ReadLine();
            }
