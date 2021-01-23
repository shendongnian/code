    public List<List<string>> PowerMultiSet (List<string> start, List<string> elems, int n )
    {
        List<List<string>> output = new List<List<string>>();
        if (n > 1)
        {
            for (int i = 0; i < elems.Count; i++)
            {
                start.Add(elems[i]);
                List<List<string>> current = PowerMultiSet(start, elems.GetRange(i, elems.Count - i), n - 1);
                start.RemoveAt(start.Count - 1);
                output.AddRange(current);
            }
        }
        else
        {
            foreach (string e in elems)
            {
                List<string> current = new List<string>(start);
                current.Add(e);
                output.Add(current);
            }
        }
        return output;
    }
