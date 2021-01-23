    var input = @"
    <strong>You</strong></font> <font size='3' color='#05ABF8'>
    <strong>Shook</strong></font> Me All <font size='3' color='#05ABF8'>
    <strong>Night</strong></font> <font size='3' color='#05ABF8'>
    <strong>Long</strong></font> mp3</a></div>";
    
    var regex = new Regex(@">(?<match>[\s|\w]+)<");
    
    var matches = regex.Matches(input).Cast<Match>()
       // Get only the values from the group 'match'
       // So, we ignore '<' and '>' characters
       .Select(p => p.Groups["match"].Value);
    var result = string.Join("", matches)
        // Remove unnecessary carriage return characters
        .Replace("\n", "")
        .Replace("\r", "");
