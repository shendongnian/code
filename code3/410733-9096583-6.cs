    public interface IRegistry
    {
        void Register(int id, string val);
        int GetFirstId();
        string Find(int id);
        ...
    }
