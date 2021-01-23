    public void RemoveRange(Predicate<T> remove)
    {
        // iterates backwards so can remove multiple items without invalidating indexes
        for (var i = Items.Count-1; i > -1; i--) {
            if (remove(Items[i]))
                Items.RemoveAt(i);
        }
        this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
        this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
