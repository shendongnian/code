    // ViewModelBase is the base class for all instance View Models
    private ViewModelBase _currentFrame;
    public ViewModelBase CurrentFrame {
      get {
        return _currentFrame;
      }
    
      private set {
        if (value == _currentFrame)
          return;
        _currentFrame = value;
        OnPropertyChanged(() => CurrentFrame);
      }
    }
