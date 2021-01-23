    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Authorize still has a Task<bool> return type
        // but await allows this nicer inline syntax
        var authorize = await Authorize(request);
        if (!authorize)
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Unauthorized.")
            };
        }
        return await base.SendAsync(request, cancellationToken);
    }
