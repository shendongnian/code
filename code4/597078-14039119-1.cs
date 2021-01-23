    private static void BoxingForEach()
    {
        IEnumerable foo = (IEnumerable)new int[10];
        foreach (int i in foo) ;
    }
    private static void NoBoxingForEach()
    {
        int[] foo = new int[10];
        foreach (int i in foo) ;
    }
    static void Main(string[] args)
    {
        MethodInfo boxingForEach = typeof(Program).GetMethod("BoxingForEach", BindingFlags.Static | BindingFlags.NonPublic);
        MethodInfo noBoxingForEach = typeof(Program).GetMethod("NoBoxingForEach", BindingFlags.Static | BindingFlags.NonPublic);
        Console.WriteLine("BoxingForEach is using boxing: {0}", 
            ILUtils.ContainsOpcodes(boxingForEach, new[] { OpCodes.Box, OpCodes.Unbox, OpCodes.Unbox_Any }));
        Console.WriteLine("NoBoxingForEach is using boxing: {0}", 
            ILUtils.ContainsOpcodes(noBoxingForEach, new[] { OpCodes.Box, OpCodes.Unbox, OpCodes.Unbox_Any }));
    }
