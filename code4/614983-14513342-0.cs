    public static double NormalizeAngle(double radians)
    {
     return System.Math.IEEERemainder(radians, Math.PI*2.0);
    }
    
    public static double ArcLength(double radians1, double radians2)
    {
     radians1 = NormalizeAngle(radians1);
     radians2 = NormalizeAngle(radians2);
     return Math.Min(NormalizeAngle(radians1 - radians2, NormalizeAngle(radians2 - radians1));
    }
