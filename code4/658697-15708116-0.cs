    private async Task<APIResponse> MakePostRequest(string RequestUrl, byte[] Content)
    {
        HttpClient  httpClient = new HttpClient();
        HttpContent httpContent = new ByteArrayContent(Content);
        APIResponse serverReply = new APIResponse();
        try {
            Console.WriteLine("Sending Request: " + RequestUrl + Content);
            HttpResponseMessage response = await httpClient.PostAsync(RequestUrl, httpContent).ConfigureAwait(false);
            // do something with the response, like setting properties on serverReply?
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine("hre.Message");
        }
        return (serverReply);
    }
