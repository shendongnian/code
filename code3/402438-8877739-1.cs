    public interface IOperand
    {
    }
    public interface IOperand<T>
    {
    }
    public interface IOperandFactory
    {
        IOperand CreateEmptyOperand();
        IOperand CreateOperand(object value);
    }
    public interface IOperandFactory<T> : IOperandFactory
    {
        new IOperand<T> CreateEmptyOperand();
        IOperand<T> CreateOperand(T value);
    }
    public class DoubleFactory : IOperandFactory<double>
    {
        public IOperand<double> CreateEmptyOperand()
        {
            throw new NotImplementedException();
        }
        public IOperand<double> CreateOperand(double value)
        {
            throw new NotImplementedException();
        }
        IOperand IOperandFactory.CreateEmptyOperand()
        {
            throw new NotImplementedException();
        }
        public IOperand CreateOperand(object value)
        {
            throw new NotImplementedException();
        }
    }
    public class SomeContainer
    {
        public SomeContainer()
        {
            var factoryDict = new Dictionary<Type, IOperandFactory>()
            {
	            { typeof(double), (IOperandFactory)new DoubleFactory() }
            };
        }
    }
