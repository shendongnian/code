    static object SomeFunctionLock = new Object();
    public static int SomeFunction(int parameter1, int parameter2){
      lock ( SomeFunctionLock ){
        return _SomeFunction( parameter1, parameter2 );
      }
    }
    [DllImport("MyDll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int _SomeFunction(int parameter1, int parameter2);
