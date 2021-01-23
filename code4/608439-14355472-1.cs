    public element read(XmlReader xml)
    {
        element elem = new element();
        while (xml.Read())
        {
    	    elem.ElemName = xml.Name;
            if (xml.HasAttributes)
            {
                for (int i = 0; i <= xml.AttributeCount; i++)
                {
                    xml.MoveToNextAttribute();
                    attribute attrib = new attribute();
                    attrib.AttName = xml.Name;
                    attrib.AttValue = xml.Value;
                    elem.Attributes.Add(attrib);
                }
            }
            if (xml.IsEmptyElement)
            {   
                return elem;
            }
            else
            {
                elem.subElems = new List<element>(); //create new List of subelements
                elem.subElems.Add(read(xml)); 
                return elem;
            }
        }
        return elem;
