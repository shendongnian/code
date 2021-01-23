    namespace Password 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
                Console.WriteLine("Please enter password:"); 
                string password = Console.ReadLine(); //Assign user-entered password 
                bool passWordMatch;
    
                passWordMatch = password == "Test";
    
                if (passWordMatch)
                {
                    Console.WriteLine(" Password Match. Access Granted");
                }
                else
                {
                    Console.WriteLine("Password doesn't match! Access denied.");
                }
            }
        }
    }
