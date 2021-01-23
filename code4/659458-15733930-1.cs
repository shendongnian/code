    public class Foo : ITag<Foo>
    {
        public bool Contains(Foo tag) ...
        bool ITag.Contains(ITag tag)
        {
            Foo other = tag as Foo;
            if (other == null)
                return false;
            return Contains(other);
        }
    }
