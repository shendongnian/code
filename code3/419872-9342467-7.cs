    var roleList = new Dictionary<string, string>();
    roleList.Add(st1.RollNo, sb1.Code);
    roleList.Add(st2.RollNo, sb2.Code);
    roleList.Add(st3.RollNo, sb2.Code);
    var subjects = new[] { sb1, sb2, sb3 }.ToDictionary(sb => sb.Code);
    Dictionary<string, List<Subject>> stSbList = roleList.ToDictionary(
        kvp => kvp.Key,
        kvp => new List<Subject> { subjects[kvp.Value] });
