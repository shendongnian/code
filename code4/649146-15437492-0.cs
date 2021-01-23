        BlobRequestOptions options = new BlobRequestOptions();
        options.UseFlatBlobListing = true;
        ResultSegment<IListBlobItem> list = Global.ContainerTools.ListBlobsSegmented(5, null, options);
        foreach (CloudBlob b in list.Results)
        {
            System.Diagnostics.Debug.WriteLine(b.Uri);
        }
        while (list.ContinuationToken != null)
        {
            list = Global.ContainerTools.ListBlobsSegmented(5, list.ContinuationToken, options);
            foreach (CloudBlob b in list.Results)
            {
                System.Diagnostics.Debug.WriteLine(b.Uri);
            }
        }
