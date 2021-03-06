    public interface ISwimBehavior
    {
        void Swin();
    }
    public interface IDuck
    {
        void ISwimBehavior { get; set; }
    }
    public class Duck : IDuck
    {
        ISwimBehavior SwimBehavior { get; set; }
    }
    public class Duck : IDuck
    {
        ISwimBehavior SwimBehavior { get { return new SwimBehavior(); }; set; }
    }
    public class ElectricDuck : IDuck
    {
        ISwimBehavior SwimBehavior { get { return new EletricSwimBehavior(); }; set; }
    }
