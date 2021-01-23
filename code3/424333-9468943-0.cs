            string result = "";
            var str = "endhelloend";
            var match = Regex.Match(str, @"end([a-z]+)end$", RegexOptions.IgnoreCase);
            if(match.Success)
            {
                result = match.Groups[1].Value;  // Returns 'hello'
            }
            Console.WriteLine(result);
            Console.ReadLine();
