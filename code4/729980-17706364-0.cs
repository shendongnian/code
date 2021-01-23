    public ErrorMessage
    {
         public string Error;
         public int ErrorCode;
    }
    ErrorMessage msg = new ErrorMessage();
    msg.Error = "Invalid Size";
    msg.ErrorCode = 500;
    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
    message.Content = new ObjectContent(typeof(MessageResponse), msg, GlobalConfiguration.Configuration.Formatters.JsonFormatter);
    throw new HttpResponseException(message);
