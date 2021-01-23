    private Action _Event;
    public event Action Event
    {
        add
        {
            _Event += value;
        }
        remove
        {
            while (_Event != null && _Event.GetInvocationList().Contains(value))
            {
                _Event -= value;
            }
        }
    }
