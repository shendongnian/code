    // Build a delegate that returns nothing and receive nothing
    // Define an event based on that delegate
    public delegate void OnSearchEnded();
    public event OnSearchEnded SearchEnded;
    ... somewhere in this class
    // If some external entity choose to be notified when whe have finished search
    // raise the event to which this external entity has subscribed (MainForm)
    if(SearchEnded != null)
        SearchEnded();
        ....
