    var payload =   
        new {
            fields = new
            {
                project = new { id = 10000 },
                summary = summary,
                description = description,
                issuetype = new { id = (int)issueTypeId }
            }
        };
    webRequest = OAuthConsumer.PrepareAuthorizedRequest(
        new MessageReceivingEndpoint(url, HttpDeliveryMethods.AuthorizationHeaderRequest | HttpDeliveryMethods.PostRequest),
        accessToken
    );
    webRequest.ContentType = "application/json";
    byte[] payloadContent = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(payload));
    webRequest.ContentLength = payloadContent.Length;
    using (var stream = webRequest.GetRequestStream())
    {
        stream.Write(payloadContent, 0, payloadContent.Length);
    }
