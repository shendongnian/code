    private long total;
    private long current;
    public double Progress
    {
        get
        {
            if (total == 0)
                return 0;
            return (double)current / total;
        }
    }
    …
    this.total = Products.LongCount();
    this.current = 0;
    
    Parallel.ForEach(Products, product =>
    {
        try
        {
            var price = GetPrice(SystemAccount, product);
            SavePrice(product, price);
        }
        finally
        {
            Interlocked.Increment(ref this.current);
        }
    });
