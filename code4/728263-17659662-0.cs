    public void Add(T item)
    {
        var key = item.ToString();
        _innerSortedList.Add(key, item);
        this.OnPropertyChanged("Count");
        this.OnPropertyChanged("Item[]");
        this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, _innerSortedList.IndexOfKey(key)));
        item.PropertyChanged += ItemPropertyChanged;
    }
    
    public bool Remove(T item)
    {
        var indexOfKey = _innerSortedList.IndexOfKey(item.ToString());
        if (indexOfKey == -1)
            return false;
        _innerSortedList.RemoveAt(indexOfKey);
        item.PropertyChanged -= ItemPropertyChanged;
        this.OnPropertyChanged("Count");
        this.OnPropertyChanged("Item[]");
        this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item,
            indexOfKey));
        return true;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _innerSortedList.Values.GetEnumerator();
    }
    
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
    {
        var handler = this.CollectionChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }
