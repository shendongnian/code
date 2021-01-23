    var uri = new Uri(input)
    if(uri.IsWellFormedOriginalString() && Bannedsites.Contains((uri.DnsSafeHost + uri.AbsolutePath)))
    {
        //Don't go to that site
    }
    else
    {
        //Go to that site
    }
