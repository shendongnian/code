    public Dictionary<string, int> GetElementMaxLength(String xsdElementName)
    {
        if (xsdElementName == null) throw new ArgumentException();
        var qname = new XmlQualifiedName(xsdElementName, null);
        var parentType = set.GlobalTypes[qname];
        return GetAllMaxLength(parentType);
    }
    private Dictionary<string, int> GetAllMaxLength(XmlSchemaObject obj)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        if (obj is XmlSchemaSimpleType)
        {
            var st = obj as XmlSchemaSimpleType;
            dict[st.QualifiedName.Name] = GetMaxLength(st);
        }
        else if (obj is XmlSchemaComplexType)
        {
            var ct = obj as XmlSchemaComplexType;
            var seq = ct.ContentTypeParticle as XmlSchemaSequence;
            foreach (var item in seq.Items)
            {
                var rng = GetAllMaxLength(item);
                foreach (var kvp in rng)
                {
                    dict[kvp.Key] = kvp.Value;
                }
            }
        }
        else if (obj is XmlSchemaElement)
        {
            var ele = obj as XmlSchemaElement;
            var type = set.GlobalTypes[ele.SchemaTypeName];
            var rng = GetAllMaxLength(type);
            foreach (var kvp in rng)
            {
                dict[String.Format("{0}/{1}", ele.QualifiedName.Name, kvp.Key)] = kvp.Value;
            }
        }
        return dict;
    }
    private Int32 GetMaxLength(XmlSchemaSimpleType xsdSimpleType)
    {
        var restriction = xsdSimpleType.Content as XmlSchemaSimpleTypeRestriction;
        if (restriction == null) return -1;
        Int32 result = -1;
        foreach (XmlSchemaObject facet in restriction.Facets)
        {
            if (facet is XmlSchemaMaxLengthFacet)
            {
                result = int.Parse(((XmlSchemaFacet)facet).Value);
                break;
            }
        }
        return result;
    }
