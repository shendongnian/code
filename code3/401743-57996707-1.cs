    public int Id { get; set; }
    public Lazy<Data> data { get; set; }
    public MyClassEager()
    {
        Id = 1;
        data = new Lazy<Data>();
    }
