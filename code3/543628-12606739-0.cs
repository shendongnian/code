    private void RaisePublicDataContextChanged()
    {
      if (this._dataContextChangedInfo == null)
        return;
      object oldValue = this._dataContextChangedInfo.OldValue;
      object dataContext = this.DataContext;
      if (oldValue == dataContext)
        return;
      this._dataContextChangedInfo.OldValue = dataContext;
      List<DependencyPropertyChangedEventHandler>.Enumerator enumerator = this._dataContextChangedInfo.ChangedHandlers.GetEnumerator();
      try
      {
        // ISSUE: explicit reference operation
        while (((List<DependencyPropertyChangedEventHandler>.Enumerator) @enumerator).MoveNext())
        {
          // ISSUE: explicit reference operation
          ((List<DependencyPropertyChangedEventHandler>.Enumerator) @enumerator).get_Current()((object) this, new DependencyPropertyChangedEventArgs(FrameworkElement.DataContextProperty, oldValue, dataContext));
        }
      }
      finally
      {
        enumerator.Dispose();
      }
    }
