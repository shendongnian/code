    public class BlobStorageHelper
    {
    	private readonly CloudBlobClient _blobClient;
    	protected readonly CloudStorageAccount StorageAccount;
    	public string _containerName { get; set; }
    
    	public BlobStorageHelper()
    		
    	{
    		_blobClient = base.StorageAccount.CreateCloudBlobClient();
    		_containerName = ConfigurationManager.AppSettings["StorageContainerName"];
    		StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
    	}
    
    	protected Stream DownloadBlobAsStream(string blobUri)
    	{
    		CloudStorageAccount account = this.StorageAccount;
    		CloudBlockBlob blob = GetBlockBlobReference(account, blobUri);
    
    		Stream mem = new MemoryStream();
    		if (blob != null)
    		{
    			blob.DownloadToStream(mem);                
    		}
    
    		return mem;
    	}
    
    	private CloudBlockBlob GetBlockBlobReference(CloudStorageAccount account, string blobUri)
    	{
    		string blobName = blobUri.Substring(blobUri.IndexOf("/" + _containerName + "/")).Replace("/" + _containerName + "/", "");
    		CloudBlobClient blobclient = account.CreateCloudBlobClient();
    		CloudBlobContainer container = _blobClient.GetContainerReference(_containerName);
    		container.CreateIfNotExists();
    		CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
    		return blob;
    	}
    
    
    	public byte[] DownloadBlobAsByeArray(string blobUri)
    	{
    		Stream inputStream = DownloadBlobAsStream(blobUri);
    
    		byte[] buffer = new byte[16 * 1024];
    
    		inputStream.Position = 0; // Add this line to set the input stream position to 0
    
    		using (MemoryStream ms = new MemoryStream())
    		{
    			int read;
    			while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
    			{
    				ms.Write(buffer, 0, read);
    			}
    			return ms.ToArray();
    		}
    	}
    
       
    }
