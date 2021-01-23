            // This is the input string.
            string input = "price+10*discount-30";
            var matches = Regex.Matches(input, @"([a-z]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
            Console.ReadLine();
