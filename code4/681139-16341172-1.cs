    public class MyViewModel: INotifyPropertyChanged {
    ...
    
    private MyModel _model;
    public MyModel Model {
      get {
        return _model;
      }
      set {
        if (value == _model)
          return;
        value = _model;
        RaisePropertyChanged(() => Model);
      }
    }
    ...
    
    }
