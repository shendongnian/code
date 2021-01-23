    List<string> list1 = new List<string>{ "N10-XX","N1-XX","N2-XX","N3-XX","N4-XX","N5-XX" };
    List<string> list2 = new List<string>() { "File (5).txt", "File (1).txt", "File (10).txt", "File (100).txt", "File (2).txt" };   
    var sortedList1 = MySort(list1).ToArray();
    var sortedList2 = MySort(list2).ToArray();
    public static IEnumerable<string> MySort(IEnumerable<string> list)
    {
        int maxLen = list.Select(s => s.Length).Max();
        Func<string, char> PaddingChar = s => char.IsDigit(s[0]) ? ' ' : char.MaxValue;
        return 
            list.Select(s =>
                    new
                    {
                        OrgStr = s,
                        SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, PaddingChar(m.Value)))
                    })
                .OrderBy(x => x.SortStr)
                .Select(x => x.OrgStr);
    }
