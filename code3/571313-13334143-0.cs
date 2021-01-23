        public interface ISomeInterface
        {
            string AMember { get; }
        }
        public abstract class BaseClass
        {
            public abstract ISomeInterface AObject { get; protected set; }
            public abstract IEnumerable<ISomeInterface> AMethod();
        }
    
        public class DerivedClass<T> : BaseClass where T : ISomeInterface
        {
            public override ISomeInterface AObject { get; protected set; }
            public override IEnumerable<ISomeInterface> AMethod()
            {
                return null;
            }
        }
