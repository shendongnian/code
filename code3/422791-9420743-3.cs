    public double[] Calculate(double aValue, double fValue, ...)
    {
        return Calculate(new double[]{aValue}, new double[]{fValue}, ...);
    }
    public double[] Calculate(IEnumerable<double> aValue, IEnumerable<double> fValue, ...)
    {
        return Calculate(aValue.ToArray(), fValue.ToArray(), ...);
    }
