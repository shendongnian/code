    public static string AsString(this XElement self)
    {
        if (self == null)
            return null;
        return self.Value;
    }
    
    public static double AsDouble(this XElement self, double defValue = default(double))
    {
        if (self == null)
            return defValue;
        double res = defValue;
        try { res = (double)self; }
        catch { }
        return res;
    }
    public static int AsInt(this XElement self, int defValue = default(int))
    {
        if (self == null)
            return defValue;
        double res = defValue;
        try { res = (double)self; }
        catch { }
        return (int)res;
    }
