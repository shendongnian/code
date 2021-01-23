    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var request = filterContext.HttpContext.Request;
        var inputStream = request.InputStream;
        inputStream.Position = 0;
        using (var reader = new StreamReader(inputStream))
        {
            string headers = request.Headers.ToString();
            string body = reader.ReadToEnd();
            string rawRequest = string.Format(
                "{0}{1}{1}{2}", headers, Environment.NewLine, body
            );
            // TODO: Log the rawRequest to your database
        }
    }
