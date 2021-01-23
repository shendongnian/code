    class Data : INotifyPropertyChanged {
    
      readonly ObservableCollection<Column> columns;
    
      Boolean allColumnsAreActive = true;
    
      Boolean allColumnsAreInactive = true;
    
      Boolean allColumnsAreActiveOrInactive = false;
    
      public Data() {
        this.columns = new ObservableCollection<Column>();
        this.columns.CollectionChanged += CollectionChanged;
      }
    
      public ObservableCollection<Column> Columns { get { return this.columns; } }
    
      public Boolean AllColumnsAreActiveOrInactive {
        get { return this.allColumnsAreActiveOrInactive; }
        set {
          if (value == this.allColumnsAreActiveOrInactive)
            return;
          this.allColumnsAreActiveOrInactive = value;
          OnPropertyChanged("AllColumnsAreActiveOrInactive");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged(String propertyName) {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    
      void CollectionChanged(Object sender, NotifyCollectionChangedEventArgs e) {
        if (e.Action == NotifyCollectionChangedAction.Reset) {
          RecomputeAllColumnsAreActiveOrInactive();
          return;
        }
        if (e.OldItems != null) {
          foreach (var item in e.OldItems.Cast<Column>())
            item.PropertyChanged -= ColumnPropertyChanged;
          RecomputeAllColumnsAreActiveOrInactive();
          return;
        }
        if (e.NewItems != null) {
          foreach (var column in e.NewItems.Cast<Column>()) {
            column.PropertyChanged += ColumnPropertyChanged;
            this.allColumnsAreActive = this.allColumnsAreActive && column.IsActive;
            this.allColumnsAreInactive = this.allColumnsAreInactive && !column.IsActive;
          }
          UpdateAllColumnsAreActiveOrInactive();
        }
      }
    
      void ColumnPropertyChanged(Object sender, PropertyChangedEventArgs e) {
        if (e.PropertyName == "IsActive") {
          var column = sender as Column;
          RecomputeAllColumnsAreActiveOrInactive();
        }
      }
    
      void RecomputeAllColumnsAreActiveOrInactive() {
        this.allColumnsAreActive = this.columns.All(c => c.IsActive);
        this.allColumnsAreInactive = this.columns.All(c => !c.IsActive);
        UpdateAllColumnsAreActiveOrInactive();
      }
    
      void UpdateAllColumnsAreActiveOrInactive() {
        AllColumnsAreActiveOrInactive = this.columns.Any()
          && (this.allColumnsAreActive || this.allColumnsAreInactive);
      }
    
    }
    
    class Column : INotifyPropertyChanged {
    
      Boolean isActive;
    
      public Boolean IsActive {
        get { return this.isActive; }
        set {
          if (this.isActive == value)
            return;
          this.isActive = value;
          OnPropertyChanged("IsActive");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected void OnPropertyChanged(String propertyName) {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    
    }
