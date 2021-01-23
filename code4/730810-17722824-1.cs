    public Something()
    {
        CreatedDT = DateTime.UtcNow;
    }
    public DateTime CreatedDT { get; private set; }
    ...
    Save(new Something());
