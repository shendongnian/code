    ...
    try
    {
        var result = membership.ValidateUser(userName, password);
        ...
    }
    catch (ProviderException e)
    {
        model.AddModelError(string.Empty, e.Message);
    }
    ...
