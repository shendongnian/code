    IList<string> lst;
    if (!_tempDicData.TryGetValue("Hello", out lst)) {
        _tempDicData.Add("Hello", lst);
    }
    lst.Add("xyz");
    lst.Add("aaa");
