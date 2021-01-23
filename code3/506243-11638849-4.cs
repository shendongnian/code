    foreach (DictionaryEntry item in set.GlobalTypes)
    {
        // set.GlobalTypes.GetEnumerator returns an object, so you need to cast to DictionaryEntry 
        // DictionaryEntry.Key and DictionaryEntry.Value are objects too so you need to cast again
        // Particle is an XmlSchemaObject, so you need to cast to an XmlSchemaSequence
        var seq = (XmlSchemaSequence)((XmlSchemaComplexType)item.Value).Particle;
        // XmlSchemaSequence.Items also returns an XmlSchemaObject so you need to cast again to XmlSchemaElement.
        foreach (XmlSchemaElement i in seq.Items)
        {
            if (i.SchemaTypeName == new XmlQualifiedName("Amount_Type"))
            {
                Console.WriteLine(i.MinOccursString);
            }
        }
    }
