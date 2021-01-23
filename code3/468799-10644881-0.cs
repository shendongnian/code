    private EventHandler _backingDelegate;
    public event EventHandler Click {
       add {
             _backingDelegate += value;
       } 
       remove {
             _backingDelegate -= value;
       }
    }
