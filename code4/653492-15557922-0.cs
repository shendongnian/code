    List<string> list = new List<string>();
    list.Add("a-b-c>d");
    list.Add("b>c-d-f");
    list.Add("c-d-f>e");
    list.Add("a-d>c-b");
    var distinctItems = list.Distinct(new KeyFuncEqualityComparer<string>(
        s => new String(s.AsEnumerable().OrderBy(c => c).ToArray())));
