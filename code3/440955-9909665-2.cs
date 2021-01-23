    var matches = Regex.Match(value, @"(.*/)([^/]+)/([^/_\.]+)[_\.][^/]*$");
    if (matches.Success)
    {
        var foldername = matches.Groups[2].Value;
        var contentname = matches.Groups[3].Value;
        var folderpath = matches.Groups[1].Value + foldername + "/";
    }
    else
    {
        // handle bad input
    }
