    abstract class TemplateMethod
    {
        protected TemplateMethod(bool recursive)
        {
            Recursive = recursive;
        }
    
        public bool Recursive { get; private set; }
        protected abstract bool ItemIsWhitelisted(SomeType item);
        public IEnumerable<SomeType> GetItems() { /* ... */ }
    }
    class Implementer : TemplateMethod
    {
        protected override bool ItemIsWhitelisted(SomeType item)
        {
            Recursive = false; // Oops; Recursive is read-only
            return item.CanFrobinate();
        }
    }
