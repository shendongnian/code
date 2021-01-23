    public class PluginElement : ConfigurationElement
    {
        public IDictionary<string, string> Attributes { get; private set; }
        public PluginElement ()
        {
            Attributes = new Dictionary<string, string>();
        }
        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            Attributes.Add(name, value);
            return true;
        }
    }
