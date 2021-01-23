    public class ObservableObject<T>
            : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public ObservableObject(T defaultValue = default(T),
                                IEqualityComparer<T> comparer = null)
        {
            this.value = defaultValue;
            this.comparer = comparer ?? EqualityComparer<T>.Default;
        }
        
        private T value;
        private IEqualityComparer<T> comparer;
        public T Value
        {
            get { return value; }
            set
            {
                if (!comparer.Equals(this.value, value))
                {
                    OnValueChanging();
                    this.value = value;
                    OnValueChanged();
                }
            }
        }
        
        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void OnValueChanging()
        {
            var propertyChanging = PropertyChanging;
            if (propertyChanging != null)
                propertyChanging(this, new PropertyChangingEventArgs("Value"));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnValueChanged()
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs("Value"));
        }
    }
