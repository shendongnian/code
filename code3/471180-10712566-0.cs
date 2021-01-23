    private static Lazy<XmlSchemaSet> internalSchema = new Lazy<XmlSchemaSet>(() => CreateSchema(SchemaType.Internal));
    private static Lazy<XmlSchemaSet> externalSchema = new Lazy<XmlSchemaSet>(() => CreateSchema(SchemaType.External));
    private static XmlSchemaSet CreateSchema(SchemaType schemaType)
    {
        var schema = new XmlSchemaSet();
        schema.Add("", CreateXmlSchemaFile(schemaType));
        return schema;
    }
    private static XmlSchemaSet GetSchema(SchemaType schemaType)
    {
        return schemaType == SchemaType.Internal 
          ? internalSchema.Value 
          : externalSchema.Value;
    }
