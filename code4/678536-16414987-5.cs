    RetryManager retryManager;
    try
    {
        retryManager = RetryPolicyFactory.CreateDefault();
    }
    catch(NullReferenceException)
    {
        throw new Exception("Unable to instantiate RetryManager, config section for TransientFaultHandling seems to be missing.");
    }
    return retryManager.GetDefaultSqlConnectionRetryPolicy();
    // below you may not need
    // var retryStrategy = RetryManager.Instance.GetRetryStrategy();
    // var retryPolicy = new RetryPolicy<SmtpFailureTransientErrorDetectionStrategy>(retryStrategy);
