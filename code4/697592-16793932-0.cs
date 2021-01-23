    public event EventHandler MyEventShortWay;
    private EventHandler _myEvent;
    public event EventHandler MyEventLongWay
    {
        add { _myEvent += value; }
        remove { _myEvent -= value; }
    }
