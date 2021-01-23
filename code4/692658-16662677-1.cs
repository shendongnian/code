     [DllImport("MathFuncs.dll", CallingConvention = CallingConvention.Cdecl)]
     public static extern Double Add(Double a, Double b);
    
     [DllImport("MathFuncs.dll", CallingConvention = CallingConvention.Cdecl)]
     public static extern Double Mul(Double a, Double b);
    
     [DllImport("MathFuncs.dll", CallingConvention = CallingConvention.Cdecl)]
     public static extern Double Sub(Double a, Double b);
    
     [DllImport("MathFuncs.dll",CallingConvention = CallingConvention.Cdecl)]
     public static extern Double Div(Double a, Double b);
    
     [DllImport("MathFuncs.dll",CallingConvention = CallingConvention.Cdecl)]
     public static extern Double Bat(Double a, Double b);
