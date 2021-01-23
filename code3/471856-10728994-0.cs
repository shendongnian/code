    public abstract class Base<T> where T : Base<T>
    {
        public bool Changed(T o)
        {
            return o == this;
        }
    }
    public class DerivedA : Base<DerivedA>
    {
    }
    public class DerivedB : Base<DerivedB>
    {
    }
