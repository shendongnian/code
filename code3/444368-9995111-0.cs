    public interface IProvider
    {
        string ProvideSomething(int id);
    }
    public interface IPreProcessor
    {
        void PreProcess(string parameter);
    }
    public interface IHandler
    {
        void HandleSomething();
    }
