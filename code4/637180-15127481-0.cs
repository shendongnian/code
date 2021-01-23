    using (var scope = new OperationContextScope(ltClient.InnerChannel))
    {
        var reqProperty = new HttpRequestMessageProperty();
        reqProperty.Headers[HttpRequestHeader.Authorization] = "Basic " 
                 + Convert.ToBase64String(Encoding.ASCII.GetBytes(
                   ltClient.ClientCredentials.UserName.UserName + ":" + 
                   ltClient.ClientCredentials.UserName.Password));
        OperationContext.Current
            .OutgoingMessageProperties[HttpRequestMessageProperty.Name] = reqProperty;
        var ltResponse = ltClient.searchEmailAddressStatusWS(ltRequest);
    }
