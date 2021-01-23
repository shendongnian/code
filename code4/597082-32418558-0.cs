    [ServiceContract]
    interface RestApi
    {
        Result Get(string id);
        Result Post(string id, Resource resource);
        Result Put(string id, Resource resource);
        void Delete(string id);
    }
