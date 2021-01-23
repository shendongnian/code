    List<string> list = new List<string>();
    list.Add("string 1");
    list.Add("string 10");
    list.Add("string 5");
    var randomOrder = list.OrderBy(x => Guid.NewGuid());
