    protected override void SetItem(int index, T item)
    {
      this.CheckReentrancy();
      T obj = this[index];
      base.SetItem(index, item);
      this.OnPropertyChanged("Item[]");
      this.OnCollectionChanged(NotifyCollectionChangedAction.Replace, (object) obj, (object) item, index);
    }
