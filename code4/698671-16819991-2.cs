    private EventHandler _fooBar;
    public event EventHandler FooBar
    {
        add
        {
            _fooBar = (EventHandler)Delegate.Combine(_fooBar, value);
        }
        remove
        {
            _fooBar = (EventHandler)Delegate.Remove(_fooBar, value);
        }
    }
