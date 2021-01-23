    public static bool TryGetValue(this XElement parent, string elementName,
                                                         out string value)
    {
        var xel = parent.Element(elementName);
        if (xel == null) {
            value = null;
            return false;
        }
        value = xel.Value;
        return true;
    }
