    public interface ISetSource
    {
        object Source { get; set; }
    }
    public class BasicInputVariable<T> : IInputVariable<T>, ISetSource
    {
        public IOutputVariable<T> Source { get; set; }
        object ISetSource.Source
        {
            get { return Source; }
            set { Source = (IOutputVariable<T>) value; }
        }
    }
