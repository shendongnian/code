    public class Plugin1 : IPlugin
    {
        public const string Name = "Plugin1";
        public const string Version = "1.0.0.0";
        public void Run()
        {
            Console.WriteLine("Plugin1 runed");
        }
    }
    // ...
    var builder = new RegistrationBuilder();
    builder
        .ForTypesDerivedFrom<IPlugin>()
        .Export<IPlugin>(exportBuilder => {
            exportBuilder.AddMetadata("Name", t => t.GetField("Name").GetRawConstantValue());
            exportBuilder.AddMetadata("Version", t => t.GetField("Version").GetRawConstantValue());
        });
