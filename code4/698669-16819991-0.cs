    private EventHandler _fooBar;
    public event EventHandler FooBar
    {
        add
        {
            if(_fooBar == null)
            {
                _fooBar = value;
            }
            else
            {
                _fooBar += value;
            }
        }
        remove
        {
            _fooBar -= value;
        }
    }
