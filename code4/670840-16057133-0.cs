    public interface IMyControl
    {
        public TClass Field { get; set; }
        public bool Enabled { get; set; }
    }
    
    class MyControl<T> : UserControl, IMyControl where T:TClass
    {
        public T Field { get; set; }
        TClass IMyControl.Field
        {
            get { return this.Field; }
            set { this.Field = (T)value; }
        }
        public event EventHandler<MyEventArgs<T>> MyEvent;
    }
