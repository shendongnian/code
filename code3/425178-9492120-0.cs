    var docTypeAlias = sender.ContentType.Alias; 
    bool hasMatch = loadedObj.Settings.Any(current => docTypeAlias.Equals(current));
    if (hasMatch)
    {
        // can work
    }
    else
    {
        // can't work
    }
