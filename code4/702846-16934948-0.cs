    public void ParseXML(object param)
    {
        var asString = param as string;
        if (asString != null)
        {
            // Do something with string.
            return;
        }
        var asXElement = param as XElement;
        if (asXElement != null)
        {
            // Do something with XElement.
            return;
        }
        // Error handling.
    }
