    public class Computer : ICloneable
    { 
        public object Clone(){ return null; }
    }
    
    public interface IFactory<T>
    {
        T Get();    
    }
    
    public interface IComputerFactory : IFactory<Computer>
    {
        Computer Get();
    }
    
    public interface ISpecialFactory<T>: IFactory<T>
        where T : ICloneable
    {
        T Get();
    }
    
    public class MyFactory : IComputerFactory, ISpecialFactory<Computer>
    {
        public Computer Get()
        {
            return new Computer();
        }
    }
