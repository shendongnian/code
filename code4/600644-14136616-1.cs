    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public sealed class SomeFeatureAttribute : Attribute
    {
        private readonly string name;
        public string Name { get { return name; } }
        public SomeFeatureAttribute(string name) { this.name = name; }
    }
