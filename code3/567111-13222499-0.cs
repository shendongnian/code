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
                    ValueChanging();
                    this.value = value;
                    ValueChanged();
                }
            }
        }
        
        public event PropertyChangingEventHandler PropertyChanging;
        protected virtual void ValueChanging()
        {
            var propertyChanging = PropertyChanging;
            if (PropertyChanging != null)
                propertyChanging(this, new PropertyChangingEventArgs("Value"));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void ValueChanged()
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs("Value"));
        }
    }
