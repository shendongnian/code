     string regexPattern = @"^+46[0-9]{9}$";
        Regex r = new Regex(regexPattern);
        foreach(string s in numbers)
        {
            if (r.Match(s).Success)
            {
                Console.WriteLine("Match");
            }
        }
