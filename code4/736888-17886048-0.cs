    /// <summary>
    /// Public event for notifying the view when a property changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;
    /// <summary>
    /// Raises the PropertyChanged event for the supplied property.
    /// </summary>
    /// <param name="name">The property name.</param>
    internal void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
