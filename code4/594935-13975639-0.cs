    .assembly 'ValidIDTest'
    {
    }
    
       .class public TestClass
       {
    	.field static public bool '_[...]'
    	
    	.method static void Main() cil managed
    	{
    		.entrypoint
    		ldsfld bool TestClass::'_[...]'
    		call void [mscorlib]System.Console::WriteLine(bool)
    	}
       }
