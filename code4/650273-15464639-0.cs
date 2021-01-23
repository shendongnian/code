    {
        string s = "1234567890";
        var lst = new List<int>();
        for (int n = 0; n < s.Length; n++)
        {
            int x;
            if (int.TryParse(s[n].ToString(), out x))
                lst.Add(x);
        }
        int[] arr = lst.ToArray();
    }
