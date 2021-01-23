    public System.Collections.IEnumerable GetItems(List<string> lst)
    {
        foreach (string s in lst)
        {
            //Some condition here to filter the list
            if (s.StartsWith("A"))
            {
                yield return s;
            }
        }
    }
