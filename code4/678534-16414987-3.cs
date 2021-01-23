    var retryManager = RetryPolicyFactory.CreateDefault();
    return retryManager.GetDefaultSqlConnectionRetryPolicy();
    // below you may not need
    // var retryStrategy = RetryManager.Instance.GetRetryStrategy();
    // var retryPolicy = new RetryPolicy<SmtpFailureTransientErrorDetectionStrategy>(retryStrategy);
