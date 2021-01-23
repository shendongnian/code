    class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!Object.Equals(field, value))
            {
                field = value;
    
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
