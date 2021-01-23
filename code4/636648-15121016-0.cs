    //CREATE FILE FROM BYTE ARRAY
    public static string createFileFromBytes(string containerName, string filePath, byte[] byteArray)
    {
    
    	try {
    
    		CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings("StorageConnectionString").ConnectionString);
    
       
    
    		CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    		CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
    		if (container.Exists == true) {
    			CloudBlockBlob blockBlob = container.GetBlockBlobReference(filePath);
    
    			try {
    				using (memoryStream == new System.IO.MemoryStream(byteArray)) {
    					blockBlob.UploadFromStream(memoryStream);
    				}
    				return "";
    			} catch (Exception ex) {
    				return ex.Message.ToString();
    			}
    		} else {
    			return "Container does not exist";
    		}
    	} catch (Exception ex) {
    		return ex.Message.ToString();
    	}
    }
