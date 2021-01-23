    public abstract class Foo
    {
        public abstract string Bar { get; }
    }
    public class Derived : Foo
    {
        public const string Constant = "value";
        public override string Bar
        {
            get { return Derived.Constant; }
        }
    }
