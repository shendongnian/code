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
