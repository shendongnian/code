    var tmpLst = panelInfo.AsEnumerable()
                 .Where(panelModel =>
                 panelModel.Field<string>(modelNumberColumnName) == solution.ModelNumber)
        .Select(panelModel => panelModel.Field<int>(voltageListSupportedColumnName))
        .Distinct()
        .ToList();
    foreach(var item in tmpLst)
    {
           voltagesSupported.AddRange(
                ModelInfoController.VoltageInfos[(uint)item]
                    .Select(voltage => (int)voltage)
                    .ToList()
    
    }
