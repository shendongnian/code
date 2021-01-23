    interface IDeserializerFunc
    {
        T Call<T>(string arg);
    }
    // ... in some class:
    void Test(IDeserializerFunc deserializer)
    {
        int x = deserializer.Call<int>("3");
        double y = deserializer.Call<double>("3.2");
    }
