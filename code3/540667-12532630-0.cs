    salesforce.SessionHeaderValue = new SforceService.SessionHeader();
    salesforce.SessionHeaderValue.sessionId = loginResult.sessionId;
    salesforce.Url = loginResult.serverUrl;
    ...
    String contactId = mySFervive.UserRegistration(....);
    Attachment a = new Attachment();
    a.Body = readFileIntoByteArray(someFile);
    a.parentId = contactId;
    a.Name = "Order #1";
    
    SaveResult sr = salesforce.create(new SObject [] {a})[0];
    if (sr.success){ 
    // sr.id contains id of newly created attachment
    } else {
     //sr.errors[0] contains reason why attachment couldn't be created.
    }
