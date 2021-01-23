    public class Person : INotifyPropertyChanged {
      private string _name;
      public string Name {
        get {
          return _name;
        }
    
        set {
          if (value == _name)
            return;
    
          _name = value;
          OnPropertyChanged(() => Name);
        }
      }
      
      // Similarly for Age ...
    }
