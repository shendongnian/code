    private static void ReadAndWriteToConsole()
        {
            var mystrings = new List<string>();
            mystrings.Add("Hello!");
            mystrings.Add("This is my command shell.");
            var input = WriteToConsole(mystrings);
            while (input.ToLower() != "exit")
            {
                mystrings.Add(input);
                Console.Clear();
                input = WriteToConsole(mystrings);
            }
        }
        private static string WriteToConsole(IEnumerable<string> variables )
        {
            foreach (var str in variables)
            {
                Console.WriteLine(str);
            }
            Console.Write("Please write something:");
            return Console.ReadLine();
        }
