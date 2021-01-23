    public static string GetRangedList(string list)
    {
        var numbers = list.Split(',').Select(int.Parse()).OrderBy(i => i);
        return string.Join(",", GetRanges(numbers));
    }
