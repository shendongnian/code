    public interface IConfig
    {
        string ValueA { get; }
        int ValueB { get; }
    }
    public class ObjectAConfig : IConfig
    {
        private class ImmutableConfig : IConfig {
            private readonly string valueA;
            private readonly int valueB;
            public ImmutableConfig(string valueA, int valueB)
            {
                this.valueA = valueA;
                this.valueB = valueB;
            }
        }
        public IConfig Build()
        {
            return new ImmutableConfig(ValueA, ValueB);
        }
        ... snip: implementation of ObjectAConfig
    }
