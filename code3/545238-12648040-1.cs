    public List<Customer> GetAllCustomers()
    {
        try
        {
            ... code to retrieve customers from datastore
        }
        catch (MyBaseException ex)
        {
             // This is an error thrown in code, don't bother logging it but relay
             // the message to the client.
             throw new FaultException(ex.Message);
        }
        catch (Exception ex)
        {
            // This is an unexpected error, we need log details for debugging
            _log.Error(ex.ToString());
            
            // and we don't want to reveal any details to the client
            throw new FaultException("Server processing error!");
        }
    }
