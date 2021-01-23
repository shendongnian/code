    var path = "/path/to/element/I/want";
    var route = path.Split(new []{'/'}, StringSplitOptions.RemoveEmptyEntries);
    XElement result = null;
    foreach (var node in route)
    {
        if (result == null)
        {
            result = _xmlDocument.Element(node);    
        }
        else
        {
            result = result.Element(node);
        }
    }
    return result;
