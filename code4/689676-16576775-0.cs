    public Code
    {
        get {
            return Payments.Select(x => x.Code)
                                  .Distinct()
                                  .Single();
        }
    }
