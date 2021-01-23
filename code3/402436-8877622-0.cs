    using System.Collections.Generic;
    using System;
    public interface IOperand
    {
        object Value { get; }
        bool IsEmpty { get; }
    }
    public abstract class Operand<T> : IOperand
    {
        public T Value { get; protected set; }
        object IOperand.Value { get { return Value; } }
        public bool IsEmpty { get; protected set; }
        public override string ToString()
        {
            return IsEmpty ? Value.ToString() : string.Empty;
        }
    }
    public class DoubleOperand : Operand<double> { }
    
    public interface IOperandFactory
    {
        IOperand CreateEmptyOperand();
        IOperand CreateOperand(object value);
    }
    public interface IOperandFactory<T> : IOperandFactory
    {
        new Operand<T> CreateEmptyOperand();
        Operand<T> CreateOperand(T value);
    }
    
    public class DoubleFactory : IOperandFactory<double>
    {
        public Operand<double> CreateEmptyOperand()
        {
            throw new NotImplementedException();
        }
        IOperand IOperandFactory.CreateEmptyOperand() {
            return CreateEmptyOperand();
        }
    
        IOperand IOperandFactory.CreateOperand(object value) {
            return CreateOperand((double)value);
        }
        public Operand<double> CreateOperand(double value)
        {
            throw new NotImplementedException();
        }
    }
    
    static class Program
    {
        static void Main()
        {
            var factoryDict = new Dictionary<Type, IOperandFactory> {
              {typeof (double), new DoubleFactory()}
            };
        }
    }
