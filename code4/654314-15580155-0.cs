    private int[] WrappedNewMethod()
    {
      return DLL.CallNewMethod();
    }
    ...SomeOtherMethod()
    {
       int[] someVariable = (DLLIsNewFormat) ? WrappedNewMethod(): new int[5];
    }
