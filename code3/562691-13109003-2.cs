    void Main()
    {
        var c = new CleanRiders(new MsSqlRepository());
        var riders = c.GetRiders();
    }
