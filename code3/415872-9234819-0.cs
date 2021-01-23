    public class Base
    {
        public abstract bool IsSatisfiedBy(string name);
        // base properties ...
    }
    public class DerivedA : Base
    {
        public override bool IsSatisfiedBy(string name)
        {
            return name == "DerivedA";
        }
    }
    public class DerivedB : Base
    {
        public override bool IsSatisfiedBy(string name)
        {
            return name == "DerivedB";
        }
    }
    public class BaseCreator
    {
        private readonly IEnumerable<Base> candidates;
        public BaseCreator(IEnumerable<Base> candidates)
        {
            this.candidates = candidates;
        }
        public Base Create(string name)
        {
            return this.candidates.First(c => c.IsSatisfiedBy(name));
        }
    }
