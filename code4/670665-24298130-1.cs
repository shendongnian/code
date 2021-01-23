    CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials("accountname", "accountkey"), true);
    var client = account.CreateCloudBlobClient();
    var container = client.GetContainerReference("containername");
    BlobContinuationToken continuationToken = null;
    string prefix = null;
    bool useFlatBlobListing = true;
    BlobListingDetails blobListingDetails = BlobListingDetails.All;
    int maxBlobsPerRequest = 10;
    List<IListBlobItem> blobs = new List<IListBlobItem>();
    do
    {
        var listingResult = await container.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxBlobsPerRequest, continuationToken, null, null);
        continuationToken = **listingResult.Result.ContinuationToken;**
        blobs.AddRange(**listingResult.Result.Results**);
    }
    while (continuationToken != null);
