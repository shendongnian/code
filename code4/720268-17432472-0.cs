    public abstract class CopyableClass
    {
        public abstract T Copy<T>() where T : CopyableClass;
    }
    public class DerivedClass : CopyableClass
    {
        public override T Copy<T>()
        {
            if(typeof(T) != typeof(DerivedClass))
                throw new ArgumentException();
            // return your copy
        }
    }
