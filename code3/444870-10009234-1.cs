    public static readonly RoutedEvent ClickEvent;         
    
    static BigLabel()    
    {    
        ClickEvent = ButtonBase.ClickEvent.AddOwner(typeof(BigLabel));    
    }    
         
    public event RoutedEventHandler Click    
    {    
        add { AddHandler(ClickEvent, value); }    
        remove { RemoveHandler(ClickEvent, value); }    
    }
