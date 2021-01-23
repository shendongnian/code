    private string _ampm;
    public string AMPM
    {
        get
        {
            return _ampm ?? ""; // Returns "" if _ampm == null
        }
        set
        {
            _ampm = value;
        }
    }
