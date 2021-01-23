        List<char> one = new List<char>("Abbbccd".ToCharArray());
        List<char> two =  new List<char>("Ebbd".ToCharArray());
        foreach (char c in two) {
            try { one.RemoveAt(one.IndexOf(c)); } catch { }
        }
        string result = new string(one.ToArray());
