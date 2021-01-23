    public bool Bold
    {
        get
        {
            return ((this.Style & FontStyle.Bold) != FontStyle.Regular);
        }
    }
