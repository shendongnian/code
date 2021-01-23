    public static readonly RoutedEvent CollectionChangedEvent = EventManager.RegisterRoutedEvent( 
        "CollectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ReplacementPatternEditor)); 
    public event RoutedEventHandler CollectionChanged
    {
        add { AddHandler(CollectionChangedEvent, value); } 
        remove { RemoveHandler(CollectionChangedEvent, value); }
    }
 
    void RaiseCollectionChangedEvent() 
    { 
        RoutedEventArgs newEventArgs = new RoutedEventArgs(ReplacementPatternEditor.CollectionChanged); 
        RaiseEvent(newEventArgs); 
    } 
