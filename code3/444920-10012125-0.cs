    using (CrmServiceClient client = CrmServiceFactory.Get("my-crm-certificate"))
    {
        client.Something();
        client.GetTradingPlatformAccountDetails();
        client.SomethingElse();
    } // client is automatically closed at the end of the 'using' block
