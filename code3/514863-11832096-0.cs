    public string GetXMLElementValue(XmlElement xElem, params string[] elementsNest)
    {
        XmlElement tempElem = xElem;
    
        foreach (string s in elementsNest)
        {
            if (tempElem.Element(s) == null)
                return string.Empty;
            else
                tempElem = tempElem.Element(s);
        }
    
        return (string) tempElem;
    }
