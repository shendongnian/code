    var list = new List<string>();
    foreach(TaxType t in Globals.TaxTypes)
    {
        list.Add(t.Name);
    }
    int selectIndex = list.FindIndex(t => t == Globals.TaxTypes.Name);
