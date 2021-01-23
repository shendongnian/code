    public interface ISerialisationService
    {
        Task<T> LoadLocalXMLAsync<T>(string filename);
        Task SaveLocalXMLAsync(string filename, object o);
    }
