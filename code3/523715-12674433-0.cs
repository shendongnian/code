        public interface IMultiPartFormDataStreamProviderWrapper : IDependency
        {
            string LocalFileName { get; }
            MultipartFormDataStreamProvider Provider { get; }
        }
    
        public class MultiPartFormDataStreamProviderWrapper : IMultiPartFormDataStreamProviderWrapper
        {
            public const string UploadPath = "~/Media/Default/Vocabulary/";
            private MultipartFormDataStreamProvider provider;
    
            public MultiPartFormDataStreamProviderWrapper(IHttpContextAccessor httpContextAccessor)
            {
                provider = new CustomMultipartFormDataStreamProvider(httpContextAccessor.Current().Server.MapPath(UploadPath));
            }
    
            public string LocalFileName
            {
                get { return provider.FileData[0].LocalFileName; }
            }
    
    
            public MultipartFormDataStreamProvider Provider
            {
                get { return provider; }
            }
        }
