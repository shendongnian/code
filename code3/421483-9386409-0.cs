    private readonly List<BankingServiceAspect> _aspects;
    private List<BankingServiceAspect> Aspects
    {
        get
        {
            if (_aspects == null) {
                _aspects = GetType()
                    .GetCustomAttributes(typeof(BankingServiceAspect), true)
                    .Cast<BankingServiceAspect>()
                    .ToList();
            }
            return _aspects;
        }
    }
