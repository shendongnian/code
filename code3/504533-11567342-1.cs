    public static Int32 ParseAsInt32(this XElement element, string attribute)
    {
        return Int32.Parse(element.Attribute(attribute).Value);
    }
    // etc, repeat for each type
