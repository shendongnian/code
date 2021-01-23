    public List<List<string>> PowerMultiSet (List<string> start, List<string> elems, int n )
    {
        List<List<string>> output = new List<List<string>>();
        if (n > 0)
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
            output.Add(new List<string>(start));
        }
        return output;
    }
