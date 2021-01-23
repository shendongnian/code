    public interface IMyControl<T> where T:class
    {
        T Field { get; set;}
        event EventHandler<MyEventArgs<T>> MyEvent;
    }
    public class MyControl<T> : UserControl, IMyControl<T> where T:class
    {
        public T Field { get; set;}
        public event EventHandler<MyEventArgs<T>> MyEvent;       
    }
