            string[] arr = new string[] { "hello world", "how are you", "what is going on" };
            HashSet<string> incuded = new HashSet<string>(arr.SelectMany(ss => ss.Split(' ')));
            string s = "hello are going on";
            string s2 = "hello world man";
            bool valid1 = s.Split(' ').All(ss => incuded.Contains(ss));
            bool valid2 = s2.Split(' ').All(ss => incuded.Contains(ss));
