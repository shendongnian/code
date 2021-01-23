    public int Value { get; set; }
    public void Foo()
    {
        int cachedValue = this.Value;
        if (cachedValue  > 0)
        {
            Console.WriteLine(cachedValue );
        }
    }
