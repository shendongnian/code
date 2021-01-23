    public class TargettedObserver<T>
    {
        private static readonly EqualityComparer<T> EqualityComparer = EqualityComparer<T>.Default;
        private Func<T> ValueTarget;
        private T OldValue;
        public event ObservedValueChangedEventHandler<T> ValueChanged;
        public TargettedObserver(Func<T> valueTarget)
        {
            this.ValueTarget = valueTarget;
            OldValue = ObtainCurrentValue();
        }
        public bool CheckValue()
        {
            T oldValue = OldValue;
            T newValue = ObtainCurrentValue();
            bool hasValueChanged = CompareValues(oldValue, newValue);
            
            if (hasValueChanged)
            {
                OldValue = newValue;
                NotifyValueChanged(oldValue, newValue);
            }
            return hasValueChanged;
        }
        private void NotifyValueChanged(T oldValue, T newValue)
        {
            var valueChangedEvent = ValueChanged;
            if (valueChangedEvent != null)
                valueChangedEvent(this, new ObservedValueChangedEventArgs<T>(oldValue, newValue));
        }
        private static bool CompareValues(T oldValue, T newValue)
        {
            return !EqualityComparer.Equals(oldValue, newValue);
        }
        private T ObtainCurrentValue()
        {
            return ValueTarget();
        }
    }
