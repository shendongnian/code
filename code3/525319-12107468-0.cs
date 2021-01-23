    public interface IPluginInterface : IEquatable<IPluginInterface>
    {
        string Maker { get; }
        string Version { get; }  
    }
    public interface IPluginWithOptionA : IPluginInterface
    {
        void Do();
    }
    public interface IPluginWithOptionB : IPluginInterface
    {
        void Do_two();
    }
