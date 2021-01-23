    try
    {
        _client.SampleMethod();
    }
    catch (FaultException<MyFaultMessage> e)
    {
        //Handle            
    }
    catch (FaultException<ExceptionDetail> exception)
    {
        //Getting original exception detail if includeExceptionDetailInFaults = true
        ExceptionDetail exceptionDetail = exception.Detail;
    }
