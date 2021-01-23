            string name = "John Clark MacDonald";
            var parts = name.Split(' ');
            string initials = "";
            foreach (var part in parts)
            {
                initials += Regex.Match(part, "[A-Z]");
                Console.WriteLine(part + " --> " + Regex.Match(part,"[A-Z]"));
            }
            Console.WriteLine("Final initials: " + initials);
            Console.ReadKey();
