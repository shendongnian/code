    public class ObservedValueChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }
        public ObservedValueChangedEventArgs(T oldValue, T newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
    public delegate void ObservedValueChangedEventHandler<T>(TargettedObserver<T> observer, ObservedValueChangedEventArgs<T> eventArgs);
