    Dictionary<string, List<string>> Dic = new Dictionary<string, List<string>>();
    Dic.Add("1", new List<string>{"ABC","DEF","GHI"});
    Dic.Add("2", new List<string>{"JKL","MNO","PQR"});
    Dic.Add("3", new List<string>{"STU","VWX","YZ"});
    List<string> strList = Dic.SelectMany(r => r.Value).ToList();
