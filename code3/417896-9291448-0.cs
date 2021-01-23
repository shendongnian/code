     foreach(string n in txtList)
        {
            string str[] = n.Split('.');
            if (str.Length > 0)
            {
                string s = str[str.Length-1];
                Console.WriteLine(s.Substring(0, s.Length-1));
            }
        }
