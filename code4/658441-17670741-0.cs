    XmlSchema xsd = XmlSchema.Read(new StreamReader(pathToxsdFile), null);
        
    var xss = new XmlSchemaSet();
        xss.Add(xsd);
        xss.Compile();
        XmlSchemaElement rootElement = null;
        foreach (DictionaryEntry item in xsd.Elements)
        {
            rootElement = item.Value as XmlSchemaElement; break;
        }
        XmlSchemaComplexType innerContent = rootElement.ElementSchemaType as XmlSchemaComplexType;
        var innerContentsOfRoot = innerContent.Particle as XmlSchemaAll;
        foreach (XmlSchemaElement item in innerContentsOfRoot.Items)
        {
            XmlSchemaComplexType moreInnerContent = item.ElementSchemaType as XmlSchemaComplexType;
            foreach (DictionaryEntry item2 in moreInnerContent.AttributeUses)
            {
                if (string.Compare(((XmlSchemaAttribute)(item2.Value)).Name, attributeName, true) == 0)
                {
                    string captionName = ((XmlSchemaAttribute)(item2.Value)).FixedValue;
                    
                }
            }
        }
