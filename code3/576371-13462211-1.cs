    private Task<IEnumerable<S3Object>> method(object sender, EventArgs e)
    {
        var listRequest = new ListObjectsRequest().WithBucketName(bucketName);
        ListObjectsResponse listResponse = null;
        return Task<ListObjectsResponse>.Factory.FromAsync(
            client.BeginListObjects, client.EndListObjects, listRequest, null)
            .ContinueWith(continuation);
    }
    
