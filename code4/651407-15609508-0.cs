    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PhotoComponent : Interfaces.IPhotoComponent
    {
        public bool UploadPhotoStream(string productid, string photoid, Stream fileData)
        {
			// some code....
        }
    }
	
	[ServiceContract]
    public interface PhotoComponent
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "UploadPhotoStream/{productid}/{photoid}", Method = "POST")]
        bool UploadPhotoStream(string productid, string photoid, System.IO.Stream fileData);
    }  
