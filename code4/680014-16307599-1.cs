    int idx = 0, loser;
    var results = data
        // turn the list of strings into one string, where we separate the groups by a delimiter
        // and the elements in the group by a different delimiter
        .Aggregate((soFar, next) => int.TryParse(next, out loser) ? soFar + "|" + next : soFar + '=' + next)
        // split by that delimiter, to get the groups
        .Split('|')
        .Select(s =>
        {
            // get the elements in the group split up
            var groupValues = s.Split('=');
            // create the resulting object, using the index
            var r = new { HeaderIndex = idx, HeaderValue = int.Parse(groupValues[0]), Details = groupValues.Skip(1).ToList() };
            // update the index
            idx += s.Length;
            return r;
        });
