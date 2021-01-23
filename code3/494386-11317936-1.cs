    public List<int> GetListIntKey(int keys)
    {
        var t = new List<int>();
    
        for (int i = 0; ; i++)
        {
            var j = GetKey((keys + i).ToString());
            int n;
            // check if it's possible to convert a number, because j is a string.
            if (int.TryParse(j, out n))
                // if it works, add on the list
                t.Add(n);
            else //otherwise it is not a number, null, empty, etc...
                break;
        }
        return t.Count == 0 ? null : t;
    }
