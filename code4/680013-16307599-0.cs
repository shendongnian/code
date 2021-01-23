    int idx = 0, loser;
    var results = data
        // turn the list of strings into one string, where we separate the groups by a delimiter
        .Aggregate((soFar, next) => int.TryParse(next, out loser) ? soFar + "|" + next : soFar + next)
        // split by that delimiter, to get the groups
        .Split('|')
        .Select(s =>
        {
            // create the resulting object, using the index
            var r = new { HeaderIndex = idx, HeaderValue = int.Parse(s.Substring(0, 1)), Details = s.Substring(1).ToCharArray() };
            // update the index
            idx += s.Length;
            return r;
        });
