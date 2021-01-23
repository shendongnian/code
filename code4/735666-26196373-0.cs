    public static class NotifyPropertyChangedExtensions
    {
      public static IObservable<PropertyChangedEventArgs> WhenPropertyChanged(this NotifyPropertyChanged notifyPropertyChanged)
      {
          return Observable.FromEvent<PropertyChangedEventHandler, PropertyChangedEventArgs>(
            ev => notifyPropertyChanged.PropertyChanged += ev, 
            ev => notifyPropertyChanged.PropertyChanged -= ev);
      }    
    }
