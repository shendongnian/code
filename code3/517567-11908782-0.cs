    [PUT("user/{UserId}")]
    public HttpResponseMessage Put(string userId)
    {
        Request.Content.LoadIntoBufferAsync().Wait();
        var paymentRequest = Request.Content.ReadAsAsync<PaymentRequest>().Result;
        var requestBody = Request.Content.ReadAsStringAsync().Result;
        // Calling business logic and so forth here
        // Return proper HttpResponseMessage here
    }
