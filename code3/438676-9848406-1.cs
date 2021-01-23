    public List<double> GetStrokeDashArray(List<double> dashLengths, double gap)
    {
        return dashLengths
            .Intersperse(2.0)
            .ToList();
    }
