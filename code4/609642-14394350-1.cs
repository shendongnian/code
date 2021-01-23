    public class KnownSetting : Setting<object>
    {
        private KnownSetting(string key, object defaultValue, Func<string, object> converter) : base(key, defaultValue, converter) { }
        public readonly static Setting<string> Name = Create<string>("name", "Default Name", t => t);
        public readonly static Setting<int> Size = Create<int>("size", 25, t => Convert.ToInt32(t));
    }
    public class Setting<T>
    {
        public string Key { get; set; }
        public T DefaultValue { get; set; }
        public Func<string, T> Converter { get; set; }
        protected static Setting<U> Create<U>(string key, U defaultValue, Func<string, U> converter)
        {
            return new Setting<U>(key, defaultValue, converter);
        }
        protected Setting(string key, T defaultValue, Func<string, T> converter)
        {
            Key = key;
            DefaultValue = defaultValue;
            Converter = converter;
        }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            var x = KnownSetting.Name;
        }
    }
