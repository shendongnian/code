    static void Main(string[] args) {
            Regex regularExpression = new Regex(@"^[a-z0-9_-]{3,16}$");
    
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
    
                    if (regularExpression.IsMatch(password))
                        Console.WriteLine("Input matches regular expression");
                    else
                        Console.WriteLine("Input DOES NOT match regular expression");
                    Console.ReadKey(); 
    
    }
