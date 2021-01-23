    public interface ISettingsWriter
    {
        bool Recursive { set; }
    }
    abstract class TemplateMethod : ISettingsWriter
    {
        public bool Recursive { get; private set; }
        bool ISettingsWriter.Recursive
        {
            set { Recursive = value; }
        }
        protected abstract bool ItemIsWhitelisted(SomeType item);
    }
    class Implementer : TemplateMethod
    {
        protected override bool ItemIsWhitelisted(SomeType item)
        {
            Recursive = true; // Oops; Recursive is still read-only;
            return true;
        }
    }
