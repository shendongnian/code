    public void MyWebServiceMethod()
    {
        var correlationId = Helper.GetCorrelationId();
        MyLog.Message("MyWebServiceMethod\tCorrelationId", correlationId);
        // ...
    }
