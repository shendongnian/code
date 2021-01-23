    public class MyBaseViewModel : INotifyPropertyChanged {
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public class A : MyBaseViewModel {
      private string _name;
      public string Name {
        get {
          return _name;
        }
        set {
          _name = value;
          OnPropertyChanged("Name");
        }
      }
    
      private ObservableCollection<B> _items;
      public ObservableCollection<B> Items {
        get {
          return _items;
        }
        set {
          _items = value;
          OnPropertyChanged("Items");
        }
      }
    }
    
    public class B : MyBaseViewModel {
      private string _name;
      public string Name {
        get {
          return _name;
        }
        set {
          _name = value;
          OnPropertyChanged("Name");
        }
      }
    
      private ObservableCollection<C> _items;
      public ObservableCollection<C> Items {
        get {
          return _items;
        }
        set {
          _items = value;
          OnPropertyChanged("Items");
        }
      }
    }
    
    public class C : MyBaseViewModel {
      private string _name;
      public string Name {
        get {
          return _name;
        }
        set {
          _name = value;
          OnPropertyChanged("Name");
        }
      }
    
      private bool _isRenaming;
      public bool IsRenaming {
        get {
          return _isRenaming;
        }
        set {
          _isRenaming = value;
          OnPropertyChanged("IsRenaming");
        }
      }
    }
