    public bool CanAutoClickNext {
      get {
        return _canAutoClickNext;
      }
    
      private set {
        if (value == _canAutoClickNext)
          return;
    
        _canAutoClickNext = value;
        RaisePropertyChanged(() => CanAutoClickNext);
    
        if (_canAutoClickNext)
          NextButtonCommand.Execute(null);
      }
    }
