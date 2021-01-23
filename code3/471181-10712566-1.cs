    if (schemaType == SchemaType.Internal)
    { 
        if (internalSchema == null)
        {
            internalSchema = new XmlSchemaSet();
            internalSchema.Add("", CreateXmlSchemaFile(schemaType));
        }
        return internalSchema;
    }
    else
    {
        if (externalSchema == null)
        {
            externalSchema = new XmlSchemaSet();
            externalSchema.Add("", CreateXmlSchemaFile(schemaType));
        }
        return externalSchema;
    }
