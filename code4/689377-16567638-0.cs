    private static string SortFrench(string langs, string setFirst)
    {
        string _frenchLangs = String.Empty;
        List<string> list = langs.Split(';').Select(s => s.Trim()).ToList();
        list.Sort();
        if (list.Contains(setFirst))
        {
            list.Remove(setFirst);
            list.Insert(0, setFirst);
        }
        _frenchLangs = string.Join(" ; ", list);
        return _frenchLangs;
    }
