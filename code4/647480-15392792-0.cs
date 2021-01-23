    public event Action _action; //an event
    
    
    if (_action != null) // are there any subscribers?
    
    {
            foreach (Action c in _action.GetInvocationList()) //get each subscriber
            {
                _action -= c; //remove its subscription to the event
            }
    }
