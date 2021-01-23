     private GameState _state;
     public GameState State 
     { 
         get { return _state; }
         set { _state = value; RaisePropertyChanged(() => State); }
     }
