    private EventHandler mouseEnter;
    public new event EventHandler MouseEnter {
    add
    {
        this.mouseEnter += value;
        foreach (Control i in Controls)
        {
            i.mouseEnter += value;
        }
    }
    remove
    {
        this.mouseEnter -= value;
        foreach (Control i in Controls)
        {
            i.mouseEnter -= value;
        }
    }
