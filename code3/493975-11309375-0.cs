    public interface IBuilder<T>
    {
        T Build();
    }
    public abstract class BaseBuilder<T> : IBuilder<T>
    {
        public abstract T Build();
    }
    public class CustomBuilder : BaseBuilder<CustomBuilder>
    {
        public override CustomBuilder Build()
        {
            throw new NotImplementedException();
        }
    } 
