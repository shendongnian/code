    public class MyObservableCollection<T> :
        IList<T>,
        IReadOnlyList<T>,
        INotifyCollectionChanged,
        INotifyPropertyChanged
    {
       // ...
    }
