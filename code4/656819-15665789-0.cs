    public interface IInterface<T>
    {
        IInterface<T> Operation();
    }
    public class Impl : IInterface<int>
    {
        public <IInterface<int>> Operation()
        {
            return new OtherType();
        }
    }
