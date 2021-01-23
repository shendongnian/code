    private TickHandler tick;
    public event TickHandler
    {
        add { tick += value; }
        remove { tick -= value; }
    }
