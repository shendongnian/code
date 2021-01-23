    var context = WebOperationContext.Current
    string accept = context.IncomingRequest.Accept;
    System.ServiceModel.Chanells.Message message = null;
    if (accept == "application/json")
       message = context.CreateJsonResponse<TwitterAndCloutData>(data);
    else if (accept == "text/xml")
       message = context.CreateXmlResponse<TwitterAndCloutData>(data);
    return message;
