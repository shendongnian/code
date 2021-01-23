    public List<int> GetListIntKey(int keys)
    {
        int j = 0;
        List<int> t = new List<int>();
        for (int i = 0; ; i++)
        {
            string s = GetKey((keys + i).ToString());
            if (Int.TryParse(s, out j))
                break;
            else
                t.Add(j);
        }
        if (t.Count == 0)
            return null;
        else
            return t;
    }
