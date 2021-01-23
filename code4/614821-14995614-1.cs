    public interface IAPICallPreHandler
    {
        ICredential GetCredential();
        string GetEndPoint();
        Dictionary<string, string> GetHeaderMap();
        string GetPayLoad();
    }
