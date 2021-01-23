    public interface IConvertToDouble<T>
       where T : IComparable
    {
        double Convert(T input);
    }
    public class NumericClass<T, U>
        where T : IComparable,
              U : IComparable
    {
        private IConvertToDouble<T> _tConverter;
        private IConvertToDouble<U> _uConverter;
        private List<T> _internalTs;
        private List<U> _internalUs;
        public NumericClass(IConvertToDouble<T> tConverter, IConvertToDouble<U> uConverter)
        {
            _tConverter = tConverter;
            _uConverter = uConverter;
            _internalTs = new List<T>();
            _internalUs = new List<U>();
        }
        public void DoLongNumericOperation()
        {
            for(int i = 0; i < innerArray.Length; i++)
            {
                // some computation goes on in here
                // for example, it could be
                double aConstant = 123.45;  
                double aScalar = 56.7
                _internalTs[i] = _tConverter.Convert(_internalTs[anIndex]) * aConstant + aScalar;
                _internalUs[i] = _uConverter.Convert(_internalUs[anIndex]) * aConstant + aScalar;
            }
        }
    }
