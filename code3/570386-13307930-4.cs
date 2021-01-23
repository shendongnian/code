    // assuming that the element with id=0 is the root element
    var rootElement = lookupTable[0];
    Traverse(rootElement, "");
    
    // remember, this is just a proof of concept, 
    // you probably need to render opening/ending tags etc.
    public Traverse(XMLConstruct xc, string indentation)
    {
        Console.WriteLine(indentation + xc.Element);
        foreach(var child in xc.Children)
            Traverse(child, indentation + "  ");
    }
