    public interface ISomeInterface
    {
        string AMember { get; }
    }
    public abstract class BaseClass<T> where T : ISomeInterface
    {
        public abstract T AObject { get; protected set; }
        public abstract IEnumerable<T> AMethod();
    }
    public class DerivedClass<T> : BaseClass<T> where T : ISomeInterface
    {
        public override T AObject { get; protected set; }
        public override IEnumerable<T> AMethod()
        {
            return null;
        }
    }
