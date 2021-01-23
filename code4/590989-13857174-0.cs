    [Serializable]
    public abstract class ConfigBase<DerivedT> where DerivedT : ConfigBase<DerivedT>
    {
        protected string FilePath;
        public string FileVersion;
        public ConfigBase() { }
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(GetType());
            using (StreamWriter writer = File.CreateText(FilePath))
            {
                xs.Serialize(writer, this);
            }
        }
        public static DerivedT Load(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(DerivedT));
            using (StreamReader reader = File.OpenText(filename))
            {
                DerivedT config = (DerivedT)xs.Deserialize(reader);
                config.FilePath = filename;
                return config;
            }
        }
    }
