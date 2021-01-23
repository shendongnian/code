    public abstract class Base<T> where T : Base<T>
    {
        public T Original { get; private set; }
        public abstract bool Changed(T o);
        public bool Changed()
        {
            return this.Changed(Original);
        }
    }
    public class DerivedA : Base<DerivedA>
    {
        public override bool Changed(DerivedA o)
        {
            throw new NotImplementedException();
        }
    }
    public class DerivedB : Base<DerivedB>
    {
        public override bool Changed(DerivedB o)
        {
            throw new NotImplementedException();
        }
    }
