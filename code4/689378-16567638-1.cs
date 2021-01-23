    private static string SortFrench(string langs, string[] setStartList)
    {
        string _frenchLangs = String.Empty;
        List<string> list = langs.Split(';').Select(s => s.Trim()).ToList();
        list.Sort();
        foreach (var item in setStartList){
        if (list.Contains(item))
        {
            list.Remove(setFirst);
        }
       }
        List<string> tempList = List<string>();
        tempList.AddRange(setStartList);
        tempList.AddRange(list);
        list = tempList;
        _frenchLangs = string.Join(" ; ", list);
        return _frenchLangs;
    }
