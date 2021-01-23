    class ChildVM : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler[] GetPropertyChangedHandlers()
        {
            return PropertyChanged.GetInvocationList().
                   OfType<PropertyChangedEventHandler>().ToArray();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
