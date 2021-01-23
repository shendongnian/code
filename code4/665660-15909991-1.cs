    IEnumerable<XElement> roles = xlServerRoles.Descendants("ServerRole");
    if (isDup)
    {
        roles = roles.Where(dp => ...);
    }
    else
    {
        roles = roles.Where(dp => ...);
    }
    var alDisabledPrograms = roles.Descendants(...)
                                   ...
