    public event PropertyChangedEventHandler PropertyChanged;
    public Boolean SetProperty<T>(string propertyName, ref T field, T value, IEqualityComparer<T> comparer)
    {
        if (!comparer.Equals(field, value))
        {
            T oldValue = field;
            field = value;
    
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
            return true;
        }
    
        return false;
    }
    
    public Boolean SetProperty<T>(string propertyName, ref T field, T value)
    {
        return SetProperty(propertyName, ref field, value, EqualityComparer<T>.Default);
    }
