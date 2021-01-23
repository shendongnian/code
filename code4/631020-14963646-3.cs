    public class Foo  : IFoo
    {
        private string _field;
        public string Property
        {
            get
            {
                Contract.Assume(_field != null);
                return _field;
            }
        }
        private void SetField()
        {
            _field = " foo ";
            
        }
        private string Method()
        {
            SetField();
            return Property.Trim();
        }
    }
----------
    [ContractClass(typeof(IFooContract))]
    public interface IFoo
    {
        string Property { get; }
    }
    [ContractClassFor(typeof(IFoo))]
    public abstract class IFooContract : IFoo
    {
        public string Property
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                throw new NotImplementedException();
            }
        }
        [ContractInvariantMethod]
        private void IFooInvariant()
        {
            Contract.Invariant(Property != null);
        }
    }
