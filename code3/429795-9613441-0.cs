        static bool Valid(string format)
        {
            List<string> allowed = new List<string> { "a", "b", "c" };
            List<char> temp = new List<char>();
            foreach (char c in format)
            {
                if (!allowed.Contains(c.ToString()))
                    return false;
                else
                {
                    if (!temp.Contains(c))
                    {
                        temp.Add(c);
                    }
                }
            }
            if (allowed.Count != temp.Count)
                return false;
            return true;
        }
        List<String> words = new List<string> {"aabb", "aacc", "aaabbcc", "aabbbcc", "aabbccd"};
            var lst = words.Where(word => Valid(word)).ToList();
