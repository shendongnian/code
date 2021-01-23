    var subjects = new[] { sb1, sb2, sb3 }.ToDictionary(sb => sb.Code);
            
    Dictionary<string, List<Subject>> stSbList =
        roleList.GroupBy(tuple => tuple.Item1)
                .ToDictionary(
                    grouping => grouping.Key,
                    grouping => grouping.Select(tuple => subjects[tuple.Item2]).ToList(),
                    EqualityComparer<string>.Default);
