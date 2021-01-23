            Console.WriteLine("Enter your Name");
            Console.WriteLine("Enter your Pswrd");
            string name = Console.ReadLine();
            string pswrd = Console.ReadLine();
            Dictionary<string, string> namesToCheck = new Dictionary<string, string>
            {
                {"John", "123456"},
                {"Harry", "someotherpassword"}
            };
            if (namesToCheck.ContainsKey(name) && namesToCheck[name] == pswrd)
            {
                Console.WriteLine("You are logged in");
            }
            else
            {
                Console.WriteLine("Incorrect name or pswrd");
            }
            Console.ReadLine();
