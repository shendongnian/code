    public interface IEmbed<T> where T: Control
    {
    }
    public class A :Control, IEmbed<A>
    {
    }
    public class B : IEmbed<B>
    {
    }
