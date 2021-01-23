    public Document<GenericDatabaseDTO, GenericDatabaseConstants.ActionType> ProcessDocument(Document<GenericDatabaseDTO, GenericDatabaseConstants.ActionType> document)  
    {
        // some special handling for this special case here...
        return base.ProcessDocument(document);
    }
