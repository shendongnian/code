    public class Setting 
    {
        [...]
        public sealed class Predefined 
        {
            private Predefined() {}
            public readonly static Setting<String> Name = new Setting<String>("name", "Default Name", t => t);
            public readonly static Setting<int> Size = new Setting<String>("size", "25", t => Converter.ToInt32);
        }
    }
