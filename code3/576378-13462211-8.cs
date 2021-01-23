    private Task<IEnumerable<S3Object>> method(object sender, EventArgs e)
    {
    
        ListObjectsResponse listResponse = null;
        return Task<ListObjectsResponse>.Factory.FromAsync(
            client.BeginListObjects, client.EndListObjects, listRequest, null)
            .ToSequence()
            .ContinueWith(continuation);
    }
    
