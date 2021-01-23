    tableServiceContext = new CustomTableServiceContext(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials);
    tableServiceContext.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
    var results = (from i in tableServiceContext.CreateQuery<BiggestFansIndex>("BiggestFansIndex").AsTableServiceQuery<BiggestFansIndex>()
        where i.PartitionKey.CompareTo(UserId.PaddedWithLeadingZeros()) >= 0
            && i.PartitionKey.CompareTo((UserId + 1).PaddedWithLeadingZeros()) < 0
        select i}).Take(1).Execute();
