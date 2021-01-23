    class Ancestor
    {
        public interface IAttributes { }
        public virtual IAttributes Attributes { get; set; } // Make this virtual
    }
    class Descendant : Ancestor
    {
        // Override here OR instead you can omit the declaration at all.
        public override IAttributes Attributes { get; set; }
        public Descendant()
        {
            this.Attributes = new DescendantAttributes();
        }
        public class DescendantAttributes : IAttributes
        {
            public string Name = "";
        }
    }
