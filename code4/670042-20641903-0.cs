                    string randomGUID = locationID
                    + "-"
                    + Guid.NewGuid().ToString();
                //Retrieve storage account from application settings
                CloudStorageAccount storageAccount = GetStorageAccount();
                //Create blob client
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                //Retrieve reference to images container
                CloudBlobContainer container = blobClient.GetContainerReference(
                    RoleEnvironment.GetConfigurationSettingValue("BlobContainer"));                    
                //Retrieve references to the blob inside the container
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(randomGUID);
                blockBlob.UploadFromStream(imageToUpload);
