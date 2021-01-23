    static Task<MemoryObject>[] GetMemoryObjectsAsync(AmazonS3 s3,
        IEnumerable<AmazonS3Request> requests)
    {
        // Just call Select on the requests, passing our translation into
        // a Task<MemoryObject>.
        // Also, materialize here, so that the tasks are "hot" when
        // returned.
        return requests.Select(r => GetMemoryObjectAsync(s3, r)).
            ToArray();
    }
    
