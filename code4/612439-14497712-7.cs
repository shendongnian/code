    public interface IPluginMetadata
    {
        string Name { get; }
        string Version { get; }
    }
    public interface IPlugin : IPluginMetadata
    {
        void Run();
    }
    
    public class Plugin1 : IPlugin
    {
        public string Name { get { return "Plugin 1"; } }
        public string Version { get { return "1.0.0.0"; } }
        public void Run()
        {
            Console.WriteLine("Plugin1 runed");
        }
    }
