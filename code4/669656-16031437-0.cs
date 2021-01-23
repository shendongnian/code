    var client = new IdentityProofingService.IdentityProofingWSClient();
    using (new OperationContextScope(client.InnerChannel))
    {
        OperationContext.Current.OutgoingMessageHeaders.Add(new SecurityHeader("UsernameToken-49", "12345/userID", "password123"));
        client.invokeIdentityService(new IdentityProofingRequest());
    }
