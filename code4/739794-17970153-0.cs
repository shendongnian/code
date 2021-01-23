    var input = File.ReadAllText("text.txt");
    var xmlStrings = Regex
        .Matches(input, @"([0-9AMP: ]*>>Response: )")
        .Cast<Match>()
        .Select(match =>
        {
            var currentPosition = match.Index + match.Length;
            var nextMatch = match.NextMatch();
            if (nextMatch.Success == true)
            {
                return input.Substring(currentPosition, 
                    nextMatch.Index - currentPosition);
            }
            else
            {
                return input.Substring(currentPosition);
            }
        });
