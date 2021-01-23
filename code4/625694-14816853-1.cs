    public static void OnPropertyChanged<T>(this  INotifyPropertyChanged target, string    propertyName, Action action)
    {
        if (target == null)
        {
            return;
        }
        // Declare the handler first, in order to create
        // a concrete reference that you can use from within
        // the delegate
        PropertyChangedEventHandler handler = null;  
        handler = (obj, e) =>
        {
            if (propertyName == e.PropertyName)
            {
                obj.PropertyChanged -= handler; //un-register yourself
                action();
            }
        };
        target.PropertyChanged += handler;
    }
