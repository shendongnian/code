    Parallel.ForEach(elements, e =>
    {
         var eResult = e.CalcKe(); 
         AggregateResults(eResult);
    }
    void AggregateResults(Matix r)
    {
        lock(denseMatrix)
            denseMatix[a,b] = r[k,l];
    }
