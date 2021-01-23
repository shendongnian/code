	ListVersionsResponse listResponse = client.ListVersions(new ListVersionsRequest { 
		BucketName = bucketName, 
		Prefix = keyName }
	);
	List<S3ObjectVersion> listversion = listResponse.Versions;
	foreach (S3ObjectVersion VersionIDs in listResponse.Versions)
	{
		if(VersionIDs.IsDeleteMarker)
		{
			DeleteObjectRequest request = new DeleteObjectRequest
			{
				BucketName = bucketName,
				Key = keyName,
				VersionId = VersionIDs.VersionId
			};
			client.DeleteObjectAsync(request);
		}	   
	}
