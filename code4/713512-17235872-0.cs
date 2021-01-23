    public class ApplicationSettings      
    {
       public ApplicationSettings()
       {
           
       }
       public ApplicationSettings(ApplicationSettings settings)
       {
           ApplicationName = settings.ApplicationName;
           EncryptionAlgorithm = settings.EncryptionAlgorithm;
           EncryptionKey = settings.EncryptionKey;
           HashAlgorithm = settings.HashAlgorithm;
           HashKey = settings.HashKey;
           Duration = settings.Duration;
           BaseUrl = settings.BaseUrl;
           Id = settings.Id;
       }
     public string ApplicationName { get; set; }
     public string EncryptionAlgorithm { get; set; }
     public string EncryptionKey { get; set; }
     public string HashAlgorithm { get; set; }
     public string HashKey { get; set; }
     public int Duration { get; set; }
     public string BaseUrl { get; set; }
     public Guid Id { get; set; }
    }
