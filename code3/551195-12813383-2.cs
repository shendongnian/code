    public interface ISettings
    {
        bool Recursive { get; }
    }
    abstract class TemplateMethod
    {
        [Import]
        public ISettings Settings { get; private set; }
        protected abstract bool ItemIsWhitelisted(SomeType item);
        public IEnumerable<SomeType> GetItems() { /* ... */ }
    }
