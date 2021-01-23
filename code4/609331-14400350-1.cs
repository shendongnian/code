    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Registration;
    
    namespace MEF2
    {
        public interface IPlugin
        {
            void Run();
        }
    
        public interface IPluginMetadata
        {
            string Name { get; }
            string Version { get; }
        }
    
        [MetadataAttribute]
        [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
        public class PluginMetadataAttribute : ExportAttribute, IPluginMetadata
        {
            public string Name { get; set; }
            public string Version { get; set; }
    
            public PluginMetadataAttribute(string name, string version)
                : base(typeof(IPlugin))
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
    
        public class PluginStore
        {
            public IEnumerable<Lazy<IPlugin, IPluginMetadata>> Plugins { get; private set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var builder = new RegistrationBuilder();
                builder
                    .ForTypesDerivedFrom<IPlugin>()
                    .Export<IPlugin>();
                builder
                    .ForType<PluginStore>()
                    .Export()
                    .ImportProperties(
                        propertyFilter => true,
                        (propertyInfo, importBuilder) => {
                            importBuilder.AsMany();
                        }
                    );
    
                var catalog = new AssemblyCatalog(typeof(PluginStore).Assembly, builder);
                
                using (var container = new CompositionContainer(catalog)) {
                    var pluginStore = container.GetExport<PluginStore>().Value;
    
                    foreach (var plugn in pluginStore.Plugins) {
                        Console.WriteLine("{0}, {1}", plugn.Metadata.Name, plugn.Metadata.Version);
                        plugn.Value.Run();
                    }
                }
            }
        }
    }
