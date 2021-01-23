    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void FuncPtr(ref IntPtr dblArr, int size);
    [DllImport("test1dll.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void callCSharpFunctionDblArr(IntPtr fctPointer);
    public static void printInConsoleDblArr(ref IntPtr nbArr, int size)
    {
        // Marshal native to managed
        double[] values = new double[size];
        Marshal.Copy(nbArr, values, 0, size);
        Console.Write("value = ");
        for (int i = 0; i < size; i++)
            Console.Write(values[i] + "; ");
        Console.WriteLine();
        for (int i = 0; i < size; i++)
            values[i] = values[i] + 1;
        Console.Write("value = ");
        for (int i = 0; i < size; i++)
            Console.Write(values[i] + "; ");
        Console.WriteLine();
        // Marshal managed to native
        Marshal.Copy(values, 0, nbArr, size);
    }
    static void Main(string[] args)
    {
        FuncPtr printInConsoleDblArrDelegate =
            new FuncPtr(printInConsoleDblArr);
        IntPtr printInConsoleDblArrPtr =
            Marshal.GetFunctionPointerForDelegate(printInConsoleDblArrDelegate);
        Console.WriteLine("Second time called from C++ using the call back !!!");
        callCSharpFunctionDblArr(printInConsoleDblArrPtr);
        Console.ReadLine();
    }
