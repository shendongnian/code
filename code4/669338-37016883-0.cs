        var request = new ListObjectsRequest()
                        .WithBucketName(bucketName)
                        .WithPrefix(this._folderPath);
        ListObjectsResponse response;
        S3Object s3Object = null;
        do
        {
            response = client.ListObjects(request);
            S3Object tempS3Object = response.S3Objects
                .Where(p => !p.Key.EndsWith("_$folder$"))
                .OrderBy(k => k.LastModified).FirstOrDefault();
            if (s3Object != null)
            {
                if (s3Object.LastModified < tempS3Object.LastModified)
                    s3Object = tempS3Object;
            }
            else s3Object = tempS3Object;
            request.Marker = response.NextMarker;
        } while (response.IsTruncated);
        var getObjectRequest = new GetObjectRequest()
            .WithBucketName(bucketName)
            .WithKey(s3Object.Key);
        GetObjectResponse getObjectResponse = client.GetObject(getObjectRequest);
        // provider 
        string provider = getObjectResponse.Metadata.Get("x-amz-meta-provider");
        string site = getObjectResponse.Metadata.Get("x-amz-meta-sitename");
        string identifier = s3Object.Key.Remove(0, this._folderPath.Length);
        string xmlData = new StreamReader(getObjectResponse.ResponseStream, true).ReadToEnd();
        return new FileMetaData()
        {
            Identifier = identifier,
            Provider = provider,
            SiteName = site,
            XmlData = xmlData
        };
