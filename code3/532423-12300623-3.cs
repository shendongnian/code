    private ChangedEventHandler _changed;
    public event ChangedEventHandler Changed
    {
       add
       {
          _changed = value; // Do NOT combine delegates
       }
       remove
       {
          _changed -= value;
       }
    }
