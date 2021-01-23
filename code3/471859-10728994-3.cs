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
    
    new DerivedA().Changed(new DerivedB()); // does not compile
    new DerivedA().Changed(new DerivedA()); // does compile
