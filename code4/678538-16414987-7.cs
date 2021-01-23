    RetryPolicy retryPolicy;
    try
    {
        retryPolicy = RetryPolicyFactory.GetDefaultSqlConnectionRetryPolicy();
    }
    catch (NullReferenceException)
    {
        throw new Exception("Unable to read transient fault handling behaviour from config, config section for TransientFaultHandling seems to be missing.");
    }
    return retryPolicy;
