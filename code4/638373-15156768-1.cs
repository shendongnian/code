    public abstract class Animal : INotifyPropertyChanged
    {
        private int _movementSpeed;
    
        public int MovementSpeed
        {
            get
            {
                return _movementSpeed;
            }
            set
            {
                if (_movementSpeed != value)
                {
                    _movementSpeed = value;
                    
                    // call this method each time a property changes
                    OnPropertyChanged(new PropertyChangedEventArgs("MovementSpeed"));
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            // always implement events like this
            // -> check if the event handler is not null, then fire it
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }
    }
