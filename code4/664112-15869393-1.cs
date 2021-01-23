    int? o = null;
    IEnumerable<XElement> rozsah = xmlText.Root
        // Getting all child 'TR_ZAL' from root object
        .Elements("TR_ZAL")
        // Ignoring until we will not meet TR_ZAL with IDZ == AWak
        .SkipWhile(x => x.Attribute("IDZ").Value != "AWak")
        // Cache the first value of elements in collection and compare each next item
        // we want to take only items which does not have the same value
        .TakeWhile(x =>
            {
                int oAttributeValue = XmlConvert.ToInt32(x.Attribute("O").Value);
    
                if (!o.HasValue)
                {
                    o = oAttributeValue;
                    return true;
                }
                else
                {
                    return o != oAttributeValue;
                }
            });
