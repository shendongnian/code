    WebProxy proxy = (WebProxy) WebRequest.DefaultWebProxy;
    if (proxy.Address.AbsoluteUri != string.Empty)
    {
        // yes! The client uses proxy!
    }
