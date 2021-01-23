    class MySearchableDataListBase<T> : INotifyPropertyChanged
    {
       List<T> _list = new List<T>();
       string _currentFilterString = "";
    
       abstract bool FilterItemPredicate(T item, string query);
       
       public abstract IEnumerable<T> FilteredItems
       {
          get {
             return _list.Where(i => FilterItemPredicate(i, _currentFilterString)).ToArray();
          }
       }
    
       public string FilterQuery
       {
          get { return _currentFilterString; }
          set {
             if (value != _currentFilterString)
             {
                 _currentFilterString = value;
                 OnPropertyChanged("FilterQuery");
                 OnPropertyChanged("FilteredItems");
             }
          }
       }
    }
