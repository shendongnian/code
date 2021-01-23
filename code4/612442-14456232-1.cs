    public abstract Component : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void NotifyPropertyChanged<T>(T oldVal, T newVal, [CallerMemberName] String propertyName = "")
        {
           var e = PropertyChanged;
           if (e != null)
           {
              e(this, new PropertyChangedExtendedEventArgs(propertyName, oldVal, newVal));
           }
        }
    }
