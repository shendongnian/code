    public class FileStorageService : Service
    {
        public HttpResult Get(GetFileStorageStream fileInformation)
        {
            var internalResult = GetFromFileStorage(fileInformation);
            var fullFilePath = Path.Combine("C:\Temp", internalResult.FileName);
            return new HttpResult(new FileInfo(fullFilePath), asAttachment: fileInformation.ForDownload);
        }
    }
    
