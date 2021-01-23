    int? MyTryParse(string s)
    {
        int i;
        return int.TryParse(s, out i) ? i : default(int?);
    }
    List<int> output =
        values
        .Select(MyTryParse)
        .Where(i => i != null)
        .Select(i => i.Value)
        .ToList();
