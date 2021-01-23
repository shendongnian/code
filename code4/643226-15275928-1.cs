        static void Main()
        {
            string[] inputs = 
            {
                "Project1 - Notepad", // True
                "Project2 - Notepad", // True
                "HeyHo - Notepad", // True
                "Nope - Won't work" // False
            };
            const string filterParam = "Notepad";
            var pattern = string.Format(@"^(?=.*\b - {0}\b).+$", filterParam);
            foreach (var input in inputs)
            {
                Console.WriteLine(Regex.IsMatch(input, pattern));
            }
            Console.ReadLine();
        }
