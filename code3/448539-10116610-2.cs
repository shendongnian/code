    private void ImportAttributeGroupMembers(XmlSchemaAttributeGroup group, string identifier, CodeIdentifiers members, CodeIdentifiers membersScope, string ns)
    {
        for (int i = 0; i < group.Attributes.Count; i++)
        {
            object obj2 = group.Attributes[i];
            if (obj2 is XmlSchemaAttributeGroup)
            {
                ...
            }
            else if (obj2 is XmlSchemaAttribute)
            {
               ...
            }
         }
         ...
    }
