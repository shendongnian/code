    // your original collection
    public IList<double> OriginalValues; //= new List<double> { -1000, 5, 7 1000 };
    public IList<double> BelowMinus180
    {
       get { return OriginalValues.Where(x => x < -180).ToList().AsReadOnly(); }
    }
    public IList<double> BetweenMinus180And180
    {
       get { return OriginalValues.Where(x => x >= -180 && x <= 180).ToList().AsReadOnly(); }
    }
    public IList<double> Above180
    {
       get { return OriginalValues.Where(x => x > 180).ToList().AsReadOnly(); }
    }
