    var uri = new Uri(input)
    if(uri.IsWellFormedOriginalString() && Bannedsites.Any(x => uri.DnsSafeHost.EndsWith(x))
    {
        // Don't go to that site
    }
    else
    {
        // Go to that site
    }
