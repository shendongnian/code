    private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value; HP_Changed(); }
    }
    public event EventHandler HPChanged;
    private void HP_Changed()
    {
        if (HPChanged != null) { HPChanged(this, new EventArgs()); }
    }
