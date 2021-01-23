    public class Base { }
    public class Derived { }
    public interface IComponent
    {
       Base GetComponent();
    }
    public interface IDerviedComponent : IComponent
    {
        Dervied GetComponent();
    }
