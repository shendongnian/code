    public interface ISomeInterface
    {
        string AMember { get; }
    }
    
    public abstract class BaseClass
    {
        public ISomeInterface AObject { get { return GetAObjectImpl(); } }     
        public IEnumerable<ISomeInterface> AMethod() { return AMethodImpl(); }
        
        protected abstract ISomeInterface GetAObjectImpl();
        protected abstract IEnumerable<ISomeInterface> AMethodImpl();
    }
    public class DerivedClass<T> : BaseClass where T : ISomeInterface
    {
        public new T AObject { get; private set; }
        
        public new IEnumerable<T> AMethod() { return Enumerable.Empty<T>(); }
        
        protected override ISomeInterface GetAObjectImpl() 
        {
            return AObject;
        }
        
        protected override IEnumerable<ISomeInterface> AMethodImpl()
        {
            return AMethod();
        }
    }
