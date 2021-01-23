    private static readonly PropertyBase SchemaStrongNameProperty = new BTS.SchemaStrongName();
    private static readonly PropertyBase MessageTypeProperty = new BTS.MessageType();
    
    public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
    {
        // Get by schema strong name (.NET type)
        string schemaStrongName = pInMsg.Context.Read(SchemaStrongNameProperty.Name.Name, SchemaStrongNameProperty.Name.Namespace) as string;
        pContext.GetDocumentSpecByName(schemaStrongName);
        
        // Get by message type (XML NS#Root Node)
        string messageType = pInMsg.Context.Read(MessageTypeProperty.Name.Name, MessageTypeProperty.Name.Namespace) as string;
        pContext.GetDocumentSpecByType(messageType);
        
        // Rest of your pipeline component's code...
    }
