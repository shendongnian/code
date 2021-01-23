    // Model
    public class A : IA { }
    // ModelLogic
    public class B : IB<A> { }
    // Model Interface
    public interface IA { }
    // ModelLogic Interface
    public interface IB<out T> where T : IA { }
