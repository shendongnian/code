    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct TParams
    {
      public int Type;
      public string Name;
      public double Amount;
    }
    [DllImport("some.dll", EntryPoint = "_Func1")]
    public static extern int Func(TParams[] arrParams, int high);
    TParams[] params = new TParams[len];
    ...populate params
    int retval = Func(params, params.Length-1);
