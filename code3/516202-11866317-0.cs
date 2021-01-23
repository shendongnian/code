    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            request.SetApplication(_appFactory());
        }
        catch (Exception ex)
        {
            object resultObject = null;
            HttpStatusCode statusCode = m_exceptionHandler != null
                ? m_exceptionHandler.HandleException(ex, out resultObject)
                : HttpStatusCode.InternalServerError;
            HttpResponseMessage responseMessage = request.CreateResponse(statusCode, resultObject ?? ex);
            return Task<HttpResponseMessage>.Factory.StartNew(() => responseMessage);
        }
        return base.SendAsync(request, cancellationToken);
    }
