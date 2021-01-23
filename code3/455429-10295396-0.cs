    Class Message
    {
       string Title {get; set;}
       string Message {get; set;}
    }
    
    Class ModuleMessage: Message
    {
       string ModuleName  {get; set;}
    }
    
    Class URLMessage: Message
    {
       string URL {get; set;}
    }
    
    Class DocumentMessage: URLMessage
    {
       string Text  {get; set;}
    }
