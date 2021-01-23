    foreach (DocumentProperty property in 
        Globals.ThisDocument.Application.ActiveDocument.BuiltInDocumentProperties)
    {
        Trace.TraceInformation("Name: {0}\tValue: {1}\tType{2}", 
            property.Name, property.Value, property.Type);
    }
    
