    public override object Serialize(IDesignerSerializationManager manager,
        object value)
    {
        //Cycle through manager.Context            
        for (int iIndex = 0; manager.Context[iIndex] != null; iIndex++)
        {
            object context = manager.Context[iIndex];
            if (context is StatementContext)
            // Get CodeStatementCollection objects from StatementContext
            {
                ObjectStatementCollection objectStatementCollection =
                    ((StatementContext)context).StatementCollection;
                // Get each entry in collection.
                foreach (DictionaryEntry dictionaryEntry in objectStatementCollection)
                    // dictionaryEntry.Key is control or component contained in CustomForm descendant class
                    // dictionartEntry.Value is CodeDOM for this control or component
                    if (dictionaryEntry.Value is CodeStatementCollection)
                        DoSomethingWith((CodeStatementCollection)dictionaryEntry.Value);
            }
            //Do something with each collection in manager.Context:
            if (context is CodeStatementCollection)
                DoSomethingWith((CodeStatementCollection)context);
        }
        // Let the default serializer do its work:
        CodeDomSerializer baseClassSerializer = (CodeDomSerializer)manager.
            GetSerializer(value.GetType().BaseType, typeof(CodeDomSerializer));
        object codeObject = baseClassSerializer.Serialize(manager, value);
    
        // Then, modify the generated CodeDOM:
        if (codeObject is CodeStatementCollection)
            DoSomethingWith((CodeStatementCollection)codeObject);
    
        // Finally, return the modified CodeDOM:
        return codeObject;
    }
