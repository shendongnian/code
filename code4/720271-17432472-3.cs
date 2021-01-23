    public abstract class CopyableClass
    {
        public T Copy<T>() where T : CopyableClass
        {
            if(GetType() != typeof(T))
                throw new ArgumentException();
            return (T) Copy();
        }
        protected abstract CopyableClass Copy();
    }
    public class DerivedClass : CopyableClass
    {
        protected override CopyableClass Copy()
        {
            return // Your copy;
        }
    }
