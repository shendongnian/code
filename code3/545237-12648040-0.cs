    [OperationContract]
    public List<Customer> GetAllCustomers()
    {
        try
        {
            ... code to retrieve customers from datastore
        }
        catch (Exception ex)
        {
            // Log the exception including stacktrace
            _log.Error(ex.ToString());
            
            // No stacktrace to client, just message...
            throw new FaultException(ex.Message);
        }
    }
