    try
    {
        var file = await folder.GetFileAsync(path);
        var lines = await FileIO.ReadLinesAsync(file);
        foreach (string line in lines)
        {
            // "line" variable should contain "account(x) string(x)"
            // You can then parse it here..
        }
    }
    ...
