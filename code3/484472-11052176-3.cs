    List<string> list = new List<string>() { 
        "Liverpool - 1",
        "Liverpool - 11",
        "Liverpool - 12",
        "Liverpool - 2",
        "West Kirby - 1",
        "West Kirby - 12",
        "West Kirby - 8" };
    var sortedList = list.CustomSort().ToArray();    
    public static class MyExtensions
    {
        public static IEnumerable<string> CustomSort(this IEnumerable<string> list)
        {
            int maxLen = list.Select(s => s.Length).Max();
            return list.Select(s => new
            {
                OrgStr = s,
                SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, char.IsDigit(m.Value[0]) ? ' ' : '\xffff'))
            })
            .OrderBy(x => x.SortStr)
            .Select(x => x.OrgStr);
        }
    }
