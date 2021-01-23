    var _keyList = new SortedList<int, List<int>>();
    var AUGroupList = ProcessSummaryData.AsEnumerable()
                      .Select(x => x.Field<int>("AUGroupID"))
                      .Distinct()
                         .Where(x => x.Field<int>("AUGroupID") == au)
                         .Select(x => x.Field<int>("ActivityUnitID"))
                         .ToList<int>();
        _keyList.Add(au, AUList);
    }
