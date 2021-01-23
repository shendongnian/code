            string item = "strawb bana as .93";
            string itemPattern = @"([\w\s]*)(\d*\.\d*)";
            var match = Regex.Match(item, itemPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                Console.WriteLine("match");
                Console.WriteLine("name: "+match.Groups[1].Value);
                Console.WriteLine("Price: "+match.Groups[2].Value);
            }
            else
                Console.WriteLine("no match");
            Console.Read();
