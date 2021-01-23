    // System.Xml.Serialization.XmlSchemaExporter
    private XmlSchemaElement ExportElement(ElementAccessor accessor)
    {
	    if (!accessor.Mapping.IncludeInSchema && !accessor.Mapping.TypeDesc.IsRoot)
	    {
		    return null;
	    }
	    if (accessor.Any && accessor.Name.Length == 0)
	    {
		    throw new InvalidOperationException(Res.GetString("XmlIllegalWildcard"));
	    }
        // truncated method body
    }
