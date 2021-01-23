    // Corrected dictionary definitions
    public Dictionary<string, int> Info { get; set; }
    public Dictionary<string, int> GetInfo(int id)
    {
        // You may want to use a local variable here instead
        Info = new Dictionary<string, int>();
        ...
        Info[PlayerOneName] = scoreOne;
        Info[PlayerTwoName] = scoreTwo;
        return Info;
    }
