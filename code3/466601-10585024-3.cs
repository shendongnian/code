    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TParams
    {
      public int Type;
      public string Name;
      public double Amount;
    }
    [DllImport("some.dll")]
    public static extern int Func(TParams[] arrParams, int high);
    TParams[] params = new TParams[len];
    ...populate params
    int retval = Func(params, params.Length-1);
