    public IEnumerator<PriceLevel> GetEnumerator()
    {
        return PriceLevels.AsEnumerable().GetEnumerator();
    }
    public IEnumerator<PriceLevel> GetEnumerator()
    {
        IEnumerable<PriceLevel> enumerator = PriceLevels;
        return enumerator.GetEnumerator();
    }
    public IEnumerator<PriceLevel> GetEnumerator()
    {
        return ((IEnumerable<PriceLevel>)PriceLevels).GetEnumerator()
    }
