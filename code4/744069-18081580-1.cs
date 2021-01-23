    public static bool DoubleEquality(double a, double b) { 
        if (double.IsNaN(a)) return double.IsNaN(b); 
        else if (double.IsInfinity(a)) return double.IsInfinity(b)
        else if (a == 0) return b == 0; 
        else return Math.Abs(a - b) <= Math.Abs(a * 1e-15); 
    } 
