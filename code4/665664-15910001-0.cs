    var query = xlServerRoles.Descendants("ServerRole");
    
    if(isDup)
    {
        query = query.Where(dp => dp.Element("ServerType").Value == currentColumn.Substring(0, currentColumn.Length - 1))
    }
    else
    {
        query = query.Where(dp => dp.Element("ServerType").Value == currentColumn)
    }
    
    var alDisabledPrograms = query.Descendants("ProgramName").Select(p => p.Value).ToList();
