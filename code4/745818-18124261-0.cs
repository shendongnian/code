    public interface IDerived
    {
        void DoSomething();
        string CommonMember { get; set; }
    }
    
    public interface IComplexDerived
    {
        IEnumerable<object> Junk { get; }
        string CommonMember { get; set; }
    }
    
    public class EitherDerived : IBase
    {
        private readonly IDerived derived;
        private readonly IComplexDerived complex;
        private readonly bool isComplex;
        
        public EitherDerived(IDerived derived)
        {
            this.derived = derived;
            this.isComplex = false;
        }
        
        public EitherDerived(IComplexDerived complex)
        {
            this.complext = complex;
            this.isComplex = true;
        }
        
        public string CommonMember
        {
            get
            {
                return isComplex ? complex.CommonMember : derived.CommonMember;
            }
            set
            {
                //...
            }
        }
        
        public TOut Either<TOut>(Func<IDerived, TOut> mapDerived, Func<IComplexDerived, TOut> mapComplex)
        {
            return isComplex ? mapComplex(complex) : mapDerived(derived);
        }
    }
