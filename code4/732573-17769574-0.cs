        string[] file = {   "cat dog lion tiger",
                        "cat dog deer bear",
                        "mouse rat bear deer",
                        "lion tiger cat dog",
                        "cat dog deer bear"};
        Dictionary<string, string> dict = new Dictionary<string, string>();
        List<string> lst = new List<string>();
        foreach (string s in file)
        {
            string[] words = s.Split(' ');
            // assumption - thare are at least 2 words in a line - validate it
            if (!dict.ContainsKey(words[1]))
            {
                lst.Add(s);
                dict.Add(words[1], words[1]);
            }
        }
        foreach (string s1 in lst)
            Console.WriteLine(s1);
