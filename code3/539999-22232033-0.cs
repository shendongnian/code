    WebRequest request = WebRequest.Create(uri);
    
    // oddity: these two .Address values are not necessarily the same!
    //  The service point appears to be related to the .Host, not the Uri itself.
    //  So, check the .Host vlaues before fussing in the debugger.
    //
    ServicePoint svcPoint = ServicePointManager.FindServicePoint(uri);
    if (null != svcPoint)
    {
        if (!request.RequestUri.Host.Equals(svcPoint.Address.Host, StringComparison.OrdinalIgnoreCase))
        {
            Debug.WriteLine(".Address              == " + request.RequestUri.ToString());
            Debug.WriteLine(".ServicePoint.Address == " + svcPoint.Address.ToString());
        }
        Debug.WriteLine(".IssuerName           == " + svcPoint.Certificate.GetIssuerName());
    }
