    var lookup = list.ToLookup(x => RoundDownToTwoSeconds(x.CreatedOnDateTime));
    ...
    private static DateTime RoundDownToTwoSeconds(DateTime input)
    {
        return new DateTime(input.Year, input.Month, input.Day, input.Hour,
                            input.Minute, (input.Second / 2) * 2,
                            input.Kind);
    }
