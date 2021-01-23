    using System;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Registration;
    using System.Reflection;
    
    namespace MEF2
    {
        public interface IPluginMetadata
        {
            string Name { get; }
            string Version { get; }
        }
    
        public interface IPlugin
        {
            void Run();
        }
    
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class PluginMetadataAttribute : Attribute, IPluginMetadata
        {
            public string Name { get; set; }
            public string Version { get; set; }
    
            public PluginMetadataAttribute(string name, string version)
            {
                Name = name;
                Version = version;
            }
        }
    
        [PluginMetadata("Plugin1", "1.0.0.0")]
        public class Plugin1 : IPlugin
        {
            public void Run()
            {
                Console.WriteLine("Plugin1 runed");
            }
        }
    
        [PluginMetadata("Plugin2", "2.0.0.0")]
        public class Plugin2 : IPlugin
        {
            public void Run()
            {
                Console.WriteLine("Plugin2 runed");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var builder = new RegistrationBuilder();
                builder
                    .ForTypesDerivedFrom<IPlugin>()
                    .Export<IPlugin>(exportBuilder => {
                        exportBuilder.AddMetadata("Name", t => t.GetCustomAttribute<PluginMetadataAttribute>().Name);
                        exportBuilder.AddMetadata("Version", t => t.GetCustomAttribute<PluginMetadataAttribute>().Version);
                    });
    
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly(), builder);
                
                using (var container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection)) {
                    var plugins = container.GetExports<IPlugin, IPluginMetadata>();
    
                    foreach (var plugin in plugins) {
                        Console.WriteLine("{0}, {1}", plugin.Metadata.Name, plugin.Metadata.Version);
                        plugin.Value.Run();
                    }
                }
            }
        }
    }
