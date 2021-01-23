    var subjects = new[] { sb1, sb2, sb3 }.ToDictionary(sb => sb.Code);
    Dictionary<string, List<Subject>> stSbList =
        RoleList.GroupBy(kvp => kvp.Key)
                .ToDictionary(
                    grouping => grouping.Key,
                    grouping => grouping.Select(kvp => subjects[kvp.Value]).ToList());
