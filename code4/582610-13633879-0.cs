    public static string HyphenateRanges(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }
        var orderedDistinct = input.Split(',')
                                    .Select(Int32.Parse)
                                    .Distinct()
                                    .OrderBy(x => x)
                                    .ToArray();
        Func<int, int, string> replaceRangeValuesWithDash =
            (x, i) =>
            i == 0 || // first
            i == orderedDistinct.Length - 1 || // last
            orderedDistinct[i + 1] - orderedDistinct[i - 1] != 2 // not in a range
                ? x.ToString()
                : "-";
        var rangeValuesDashed = orderedDistinct
            .Select(replaceRangeValuesWithDash)
            .ToList();
        var extraDashesRemoved = rangeValuesDashed
            .Where((x, i) => i == 0 || rangeValuesDashed[i - 1] != x)
            .ToArray();
        var formattedString = String.Join(",", extraDashesRemoved)
                                    .Replace(",-,", "-");
        return formattedString;
    }
