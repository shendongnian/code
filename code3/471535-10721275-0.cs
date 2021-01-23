    List<object> results = new List<object>();
    
    string[] arrSearchFilter = SearchFilter.Split(',');
    for (int i = 0; i < arrSearchFilter.Length; i++)
    {
        var pData = ctr.GetAllProjectsNoLOCandSt(
                            Convert.ToInt16(arrSearchFilter[i]), this.ModuleId);
        foreach (var result in pData)
            results.Add(result);
    }
    // do something with `results` collection
