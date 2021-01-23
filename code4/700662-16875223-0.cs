    class Ancestor
    {
        public interface IAttributes { }
        public virtual IAttributes Attributes; // Make this virtual
    }
    class Descendant : Ancestor
    {
        public override IAttributes Attributes; // Override here OR instead you can
                                                // omit the declaration at all.
        public Descendant()
        {
            this.Attributes = new DescendantAttributes();
        }
        public class DescendantAttributes : IAttributes
        {
            public string Name = "";
        }
    }
