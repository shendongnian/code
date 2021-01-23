    public interface IDataProcessor
    {
        void Process(Data data);
        bool SupportsVersion(int version);
    }
