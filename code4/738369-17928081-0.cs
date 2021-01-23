    using (StreamReader sr = new StreamReader(path)) 
    {
        while (sr.Peek() >= 0) 
        {
            string line = sr.ReadLine();
            string[] words = line.Split();
            foreach(string word in words)
            {
                foreach(Char c in word)
                {
                    // ...
                }
            }
        }
    }
