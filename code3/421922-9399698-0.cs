    public void Initialize(ClassB fixed)
    {
        Parallel.ForEach(itemCollection, new ParallelOptions() { MaxDegreeOfParallelism = 100 },
                    (item, i, j) =>
                         {
    
                             this.InitializeStock(fixed, item);
    
                         });
    }  
      
