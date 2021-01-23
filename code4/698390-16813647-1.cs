            Dictionary<string, string> namesToCheck = new Dictionary<string, string>
            {
                {"John", "123456"},
                {"Harry", "someotherpassword"}
            };
            Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Pswrd");
            string pswrd = Console.ReadLine();
            if (namesToCheck.ContainsKey(name) && namesToCheck[name] == pswrd)
            {
                Console.WriteLine("You are logged in");
            }
            else
            {
                Console.WriteLine("Incorrect name or pswrd");
            }
            Console.ReadLine();
