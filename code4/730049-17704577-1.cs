    Parallel.ForEach(this.AllParameters, par =>
    {
        foreach (Parameter subPar in par.WrappedSubParameters)
        {
            subPar.IsSelected = false;
        }
        par.IsSelected = false;
    });
