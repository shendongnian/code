        var inputString = "AnyStringThatYouWantToSplitOnCap";
        var pattern = "[A-Z][a-z]+";
        Regex regex = new Regex(pattern);
        var matches = regex.Matches(inputString);
        StringBuilder value = new StringBuilder();
        foreach (Match item in matches)
        {
            value.AppendFormat("{0} ", item.Value);
        }
