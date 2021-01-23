    var loadbalancerReceivedSSLRequest = string.Equals(Request.Headers["X-Forwarded-Proto"], "https");
    var serverReceivedSSLRequest = Request.IsSecureConnection;
    if (loadbalancerReceivedSSLRequest || serverReceivedSSLRequest)
    {
        // SSL in use.
    }
    else
    {
        // SSL not in use.
    }
