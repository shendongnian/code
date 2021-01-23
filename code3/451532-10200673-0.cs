    void StripNamespaces(XElement input, XElement output)
    {
        foreach (XElement child in input.Elements())
        {
            XElement clone = new XElement(child.Name.LocalName);
            output.Add(clone);
            StripNamespaces(child, clone);
        }
        foreach (XAttribute attr in input.Attributes())
        {
            try
            {
                output.Add(new XAttribute(attr.Name.LocalName, attr.Value));
            }
            catch (Exception e)
            {
                // Decide how to handle duplicate attributes
                //if(e.Message.StartsWith("Duplicate attribute"))
                //output.Add(new XAttribute(attr.Name.LocalName, attr.Value));
            }
        }
    }
