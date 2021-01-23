    private static RoutedUICommand _GrowingOperation;
    public static RoutedCommand GrowingOperation
    {
        get
        {
            if(_GrowingOperation == null)
            {
                _GrowingOperation = new RoutedUICommand("GrowingOperation", 
                                    "GrowingOperation", typeof(WINDOWNAME));
            }
            return _GrowingOperation;
    }
