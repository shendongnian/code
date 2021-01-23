    public interface IMyConfigRepository
    {
        MyConfig Load();
        void Save(MyConfig settings);
    }
