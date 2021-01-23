    List<string> list1 = new List<string>() { "11c22", "1", "10", "11", "11a", "11b", "12", "2", "20", "21a", "21c", "A1", "A2" };
    List<string> list2 = new List<string>() { "File (5).txt", "File (1).txt", "File (10).txt", "File (100).txt", "File (2).txt" };
    var sortedList1 = NaturalSort(list1).ToArray();
    var sortedList2 = NaturalSort(list2).ToArray();
---
    public static IEnumerable<string> NaturalSort(IEnumerable<string> list)
    {
        int maxLen = list.Select(s => s.Length).Max();
        Func<string, char> PaddingChar = s => char.IsDigit(s[0]) ? ' ' : char.MaxValue;
        return list
                .Select(s =>
                    new
                    {
                        OrgStr = s,
                        SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, PaddingChar(m.Value)))
                    })
                .OrderBy(x => x.SortStr)
                .Select(x => x.OrgStr);
    }
