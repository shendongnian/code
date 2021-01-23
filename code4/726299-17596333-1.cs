    public interface IMyInterface2<T>
    {
            T My();
    }
    public class MyConcrete2 : IMyInterface2<string>
    {
        public string My()
        {
            throw new NotImplementedException();
        }
    }
