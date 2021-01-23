    public class Observable : INotifyPropertyChanged
    {
        public Observable();
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void NotifyPropertyChanged<T>(Expression<Func<T>> property);
    }
