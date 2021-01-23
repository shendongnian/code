    public override async Task Invoke(OwinRequest request, OwinResponse response)
    {
        request.OnSendingHeaders(state =>
            {
                var resp = (OwinResponse)state;
                resp.SetHeader("X-MyResponse-Header", "Some Value");
                resp.StatusCode = 403;
            }, response);
        var header = request.GetHeader("X-Whatever-Header");
        await Next.Invoke(request, response);
    }
