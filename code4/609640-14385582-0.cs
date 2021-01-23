    public class KnownSetting
    {
        public readonly static KnownSetting<String> Name = new KnownSetting<String>("name", "Default Name", t => t);
        public readonly static KnownSetting<int> Size = new KnownSetting<String>("size", "25", t => Converter.ToInt32);
    }
