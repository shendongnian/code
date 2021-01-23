    public override void Add(T item) {
      var e = new BeforeCollectionChangedEventArgs();
      RaiseBeforeCollectionChanged(e);
      if (!e.Canceled)
        base.Add(item);
    }
