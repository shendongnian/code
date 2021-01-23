    var nick = result.Entities[0].Attributes["nick"]
        .GetType()
        .GetProperty("Value")
        .GetValue(result.Entities[0].Attributes["nick"], null);
    var mail = result.Entities[0].Attributes["mail"]
        .GetType()
        .GetProperty("Value")
        .GetValue(result.Entities[0].Attributes["mail"], null);
    
    var contact = new Contact
    {
        Name = nick,
        Mail = mail
    };
