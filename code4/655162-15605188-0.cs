    public abstract class Foo
    {
        public abstract IList ListObject { get; }
    }
    public class Bar : Foo
    {
        public override IList ListObject
        {
            get { return new List<string>(); }
        }
    }
