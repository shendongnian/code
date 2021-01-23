    public static int get_title_year(string title)
    {
        string pattern = @"\b(?<Year1>\d{4})\b";
        Regex regex = new Regex(pattern);
        int year = regex.Matches(title)
                        .Cast<Match>()
                        .Select(m => int.Parse(m.Value))
                        .LastOrDefault();
        return year;
    }
