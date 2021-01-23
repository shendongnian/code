    string result = DoStuff(type, input1, input2, input3, true);
    XDocument d = new XDocument();
    XDocument basis = new XDocument(new XElement("result"));
    // Load the result into a XDocument, add the result as a value of the wrapper element if the format is invalid    
    try
    {
        d = XDocument.Parse(result);
        basis.Root.Add(d.Root);
    }
    catch (Exception)
    {
        basis.Root.Value = result;
    }    
    // Return the XElement
    return basis.Root;
