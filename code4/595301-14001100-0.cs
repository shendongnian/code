    private static EventHandler customEvent;
    public static event EventHandler CustomEvent
    {
        add    { customEvent += value; }
        remove { customEvent -= value; }
     }
    private static void Func()
    {
        var tmp = customEvent;
        if (tmp != null) tmp(null, null);
    }
