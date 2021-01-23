    namespace FnCallBeforeConstructor
    {
    	static void Main(string[] args)
    	{
    		MyClass s = new MyClass();
    
    		Console.ReadKey();
    	}
    		
        partial class  MyClass: Master
        {
            public override void Func()
            {
                Console.WriteLine("I am a function");
            }
     
            public MyClass()
                : base()
            {
                Console.WriteLine("I am a constructor");
            }
        }
     
        class Master
        {
            public virtual void Func() { Console.WriteLine("Not called"); }
     
            public Master()
            {
                Func();
            }
        }
    }
