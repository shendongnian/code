    public static bool AnyWordStartsWith(this string input, string test)
    {
        return input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Any(x => x.StartsWith(test));
    }
