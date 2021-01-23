    public interface ISetupXml
    {
        void SetSubSetups(Collection<SubSetupXml> setups);
    }
    [Serializable]
    [XmlSerializerAssembly]
    [XmlRoot("setup")]
    public class SetupXml : ISetupXml
    {
        public SetupXml()
        {
            SubSetups = new Collection<SubSetupXml>();
        }
        [XmlArray("subSetups")]
        [XmlArrayItem("subSetup")]
        public Collection<SubSetupXml> SubSetups { get; private set; }
        void ISetupXml.SetSubSetups(Collection<SubSetupXml> setups)
        {
            SubSetups = setups;
        }
    }
