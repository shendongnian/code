        int x = 3, y = 10;
        var lst = new List<int>{ 1, 2, 3, 4 };
        int n = (int)Math.Pow(2, lst.Count);
        var lst2 = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            var lstCopy = new int[lst.Count];
            lst.CopyTo(lstCopy);
            for (int j = 1; j <= i; j *= 2)
                if ((j & i) != 0)
                    lstCopy[(int)Math.Log(j, 2)] *= -1;
            lst2.Add(lstCopy.ToList());
        }
        bool yes = lst2.Select(l=>x + l.Sum()).Any(l=>l > 0 && l < y);
        if (yes)
            Console.WriteLine(lst2.Select(l => x + l.Sum()).Where(l => l > 0 && l < y).First());
