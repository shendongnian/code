    using Microsoft.Xrm.Sdk;
    ...
    var nick = (AliasedValue)result.Entities[0].Attributes["nick"];
    var mail = (AliasedValue)result.Entities[0].Attributes["mail"];
    
    var contact = new Contact
    {
        Name = nick.Value, //Value is of type object; cast again for a more specific type
        Mail = mail.Value
    };
