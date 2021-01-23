    long total = Products.LongCount();
    long current = 0;
    double Progress = 0.0;
    var lockTarget = new object();
    Parallel.ForEach(Products, product =>
    {
        try
        {
            var price = GetPrice(SystemAccount, product);
            SavePrice(product,price);
        }
        finally
        {
            lock (lockTarget) {
                Progress = ++this.current / total;
            }
        }});
