    public void Slow()
    {
        var end = DateTime.Now + TimeSpan.FromSeconds(10);
        while (DateTime.Now < end)
               /*nothing here */ ;
    }
