        MatchCollection matches = Regex.Matches(inputString, @".*?([-]{0,1} *\d+.\d+)");
        List<double> doubles = new List<double>();
        foreach (Match match in matches)
        {
            string value = match.Groups[1].Value;
            value = value.Replace(" ", "");
            doubles.Add(double.Parse(value));
        } 
