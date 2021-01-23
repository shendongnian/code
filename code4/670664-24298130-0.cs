        var listingResult = await container.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxBlobsPerRequest, continuationToken, null, null);
        continuationToken = **listingResult.Result.ContinuationToken;**
        blobs.AddRange(**listingResult.Result.Results**);
    }
    while (continuationToken != null);
