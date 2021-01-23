    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Test();
        }
        private void Test()
        {
            //Export
            var catalog = new AssemblyCatalog(this.GetType().Assembly);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            //Import Meta Data
            var imports = container.GetExports<IMagic1, PluginAttributeView>().Select(e => e.Metadata.Attributes).ToList();
            var results = new List<PluginAttribute>();
            foreach (var import in imports)
            {
                foreach (var plugin in import)
                {
                    if (plugin.PluginType.Equals(typeof(IMagic1)))
                    {
                        results.Add(plugin);
                    }
                }
            }
        }
    }
    public interface IPluginAttributeView
    {
        string PluginName { get; set; }
        string PluginConfigurationName { get; set; }
        string PluginCategory { get; set; }
        Type PluginType { get; set; }
    }
    public class PluginAttributeView
    {
        public List<PluginAttribute> Attributes { get; set; }
        public PluginAttributeView(IDictionary<string, object> aDict)
        {
            string[] p1 = aDict["PluginName"] as string[];
            string[] p2 = aDict["PluginConfigurationName"] as string[];
            string[] p3 = aDict["PluginCategory"] as string[];
            Type[] p4 = aDict["PluginType"] as Type[];
            Attributes = new List<PluginAttribute>();
            for (int i = 0; i < p1.Length; i++)
            {
                Attributes.Add(new PluginAttribute(p1[i], p2[i], p3[i], p4[i]));
            }
        }
    }
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class PluginAttribute : ExportAttribute, IPluginAttributeView
    {
        public string PluginName { get; set; }
        public string PluginConfigurationName { get; set; }
        public string PluginCategory { get; set; }
        public Type PluginType { get; set; }
        public PluginAttribute(string pluginName, string pluginConfigurationName, string pluginCategory, Type pluginType) : base(pluginType)
        {
            PluginName = pluginName;
            PluginConfigurationName = pluginConfigurationName;
            PluginCategory = pluginCategory;
            PluginType = pluginType;
        }
    }
    public interface IMagic1
    {
        void DoMagic1();
    }
    public interface IMagic2
    {
        void DoMagic2();
    }
    [PluginAttribute("PluginName1", "PluginConfig1.json", "Magic1", typeof(IMagic1))]
    [PluginAttribute("PluginName2", "PluginConfig2.json", "Magic2", typeof(IMagic2))]
    public class DoSomeMagic : IMagic1, IMagic2
    {
        public void DoMagic1()
        {
        }
        public void DoMagic2()
        {
        }
    }
