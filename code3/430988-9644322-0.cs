    public string TryGetAttributeValue(string attribName)
    {
        // Return attribute value, or null.
    }
    public bool ParseNode()
    {
        if ((TryGetAttributeValue(attribName1)
            ?? TryGetAttributeValue(attribName2)
            ?? TryGetAttributeValue(attribName3)) != null) {
            // Do work.
        }
    }
