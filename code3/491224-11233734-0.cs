    public double Min(double a, double b, double c)
    {
        double result = a;
        if (result < b)
        {
           result = b;
        }
        if (result < c)
        {
           result = c;
        }
        return result;
    }
