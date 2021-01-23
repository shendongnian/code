    public interface IAsyncSearch<TData, TArgs>
    {
        event EventHandler<SpecialDataEventArgs<TArgs>> SearchCompletedEvent;
        void SearchAsync(TData term);
    }
    public class SpecialDataEventArgs<T> : EventArgs
    {
        public SpecialDataEventArgs(T data)
        {
            Data = data;
        }
        public T Data { get; private set; }
    }
