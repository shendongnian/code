    // System.Xml.Serialization.XmlReflectionImporter
    private static ElementAccessor 
        CreateElementAccessor(TypeMapping mapping, string ns)
    {
	    ElementAccessor elementAccessor = new ElementAccessor();
	    bool flag = mapping.TypeDesc.Kind == TypeKind.Node;
	    if (!flag && mapping is SerializableMapping)
	    {
		    flag = ((SerializableMapping)mapping).IsAny;
	    }
	    if (flag)
	    {
		    elementAccessor.Any = true;
	    }
	    else
	    {
		    elementAccessor.Name = mapping.DefaultElementName;
		    elementAccessor.Namespace = ns;
	    }
	    // truncated
    }
