    public Dictionary<string, int> GetElementMaxLength(String xsdElementName)
    {
        if (xsdElementName == null) throw new ArgumentException();
        // if your XSD has a target namespace, you need to replace null with the namespace name
        var qname = new XmlQualifiedName(xsdElementName, null);
 
        // find the type you want in the XmlSchemaSet    
        var parentType = set.GlobalTypes[qname];
        // call GetAllMaxLength with the parentType as parameter
        var results = GetAllMaxLength(parentType);
        return results;
    }
    private Dictionary<string, int> GetAllMaxLength(XmlSchemaObject obj)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
 
        // do some type checking on the XmlSchemaObject
        if (obj is XmlSchemaSimpleType)
        {
            // if it is a simple type, then call GetMaxLength to get the MaxLength restriction
            var st = obj as XmlSchemaSimpleType;
            dict[st.QualifiedName.Name] = GetMaxLength(st);
        }
        else if (obj is XmlSchemaComplexType)
        {
            // if obj is a complexType, cast the particle type to a sequence
            //  and iterate the sequence
            //  warning - this will fail if it is not a sequence, so you might need
            //  to make some adjustments if you have something other than a xs:sequence
            var ct = obj as XmlSchemaComplexType;
            var seq = ct.ContentTypeParticle as XmlSchemaSequence;
            foreach (var item in seq.Items)
            {
                // item will be an XmlSchemaObject, so just call this same method
                //  with item as the parameter to parse it out
                var rng = GetAllMaxLength(item);
                // add the results to the dictionary
                foreach (var kvp in rng)
                {
                    dict[kvp.Key] = kvp.Value;
                }
            }
        }
        else if (obj is XmlSchemaElement)
        {
            // if obj is an XmlSchemaElement, the you need to find the type
            //  based on the SchemaTypeName property.  This is why your 
            //  XmlSchemaSet needs to have class-level scope
            var ele = obj as XmlSchemaElement;
            var type = set.GlobalTypes[ele.SchemaTypeName];
            // once you have the type, call this method again and get the dictionary result
            var rng = GetAllMaxLength(type);
            // put the results in this dictionary.  The difference here is the dictionary
            //  key is put in the format you specified
            foreach (var kvp in rng)
            {
                dict[String.Format("{0}/{1}", ele.QualifiedName.Name, kvp.Key)] = kvp.Value;
            }
        }
        return dict;
    }
    private Int32 GetMaxLength(XmlSchemaSimpleType xsdSimpleType)
    {
        // get the content of the simple type
        var restriction = xsdSimpleType.Content as XmlSchemaSimpleTypeRestriction;
        // if it is null, then there are no restrictions and return -1 as a marker value
        if (restriction == null) return -1;
        Int32 result = -1;
        // iterate the facets in the restrictions, look for a MaxLengthFacet and parse the value
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
