    private int? _relativeCost
    public int RelativeCost {
        get {
           if  (!_relativeCost.HasValue)
                _relativeCost = GetRelativeCost();
           return _relativeCost;
        }
    }
