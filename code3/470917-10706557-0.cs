    var resultList = myStringsList
        .Select(item => item.Split(new[] { '_' }, SSO.RemoveEmptyEntries))
        .Where(splitted => splitted.Length >= 3)
        .Where(splitted => splitted[1] == one && splitted[2] == two)
        .ToList();
