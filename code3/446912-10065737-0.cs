            string pattern = @"(if)|(\()|(\))|(\,)";
            string str = "IF(SUM(IRS5555.IRs001)==IRS5555.IRS001,10,20)";
            var substrings = Regex.Split(str, pattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrEmpty(n));
            foreach (string match in substrings)
            {
                Console.WriteLine("Token is:{0}", match);
            }
