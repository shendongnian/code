    class Program
    {
        static void Main(string[] args)
        {
            var f = Fruit.Apple;
            var result = f.HasFlag(Fruit.Apple);
            
            Console.ReadLine();
        }
    }
    [Flags]
    enum Fruit
    {
        Apple
    }
    .method private hidebysig static 
    	void Main (
    		string[] args
    	) cil managed 
    {
    	// Method begins at RVA 0x2050
    	// Code size 28 (0x1c)
    	.maxstack 2
    	.entrypoint
    	.locals init (
    		[0] valuetype ConsoleApplication1.Fruit f,
    		[1] bool result
    	)
    
    	IL_0000: nop
    	IL_0001: ldc.i4.0
    	IL_0002: stloc.0
    	IL_0003: ldloc.0
    	IL_0004: box ConsoleApplication1.Fruit
    	IL_0009: ldc.i4.0
    	IL_000a: box ConsoleApplication1.Fruit
    	IL_000f: call instance bool [mscorlib]System.Enum::HasFlag(class [mscorlib]System.Enum)
    	IL_0014: stloc.1
    	IL_0015: call string [mscorlib]System.Console::ReadLine()
    	IL_001a: pop
    	IL_001b: ret
    } // end of method Program::Main
