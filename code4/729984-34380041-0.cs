    HttpResponseMessage message = new  HttpResponseMessage(HttpStatusCode.InternalServerError); 
    message.Content = new ObjectContent(typeof(MessageResponse),
                                        "Invalid Size",
                                        GlobalConfiguration.Configuration.Formatters.JsonFormatter); 
    throw new HttpResponseException(message);
