    public interface IImageable<T> where T : Visual
    {
        MyReturnType ToWmf();
    }
    public class MyImageable : IImageable<XXX> // does not work if XXX is not a Visual / inherited from Visual
    {
       //implements MyReturnType ToWmf();
    }
