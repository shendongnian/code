    public abstract class PropertyChangedBase: INotifyPropertyChanged
    {
        protected PropertyChangedBase()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null)
            {
                changed(this, propertyChangedEventArgs);
            }
        }
    }
