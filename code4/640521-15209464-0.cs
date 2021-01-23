    using System;
    
    namespace Test
    {
    	interface IFoo
    	{
    		int Foobar{get;set;}
    	}
    	struct Foo : IFoo 
    	{
    		public int Foobar{ get; set; }
    	}
    	
    	class Bar
    	{
    		Foo tmp;
    		//public IFoo Biz; //behavior #1
    		public IFoo Biz{ get { return tmp; } set { tmp = (Foo) value; } } //behavior #2
    
    		public Bar()
    		{
    			Biz=new Foo(){Foobar=0};
    		}
    	}
    		
    
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var b=new Bar();
    			var f=b.Biz;
    			f.Foobar=123; 
    			Console.WriteLine(f.Foobar); //123 in both
    			b.Biz.Foobar=567; /
    			Console.WriteLine(b.Biz.Foobar); //567 in behavior 1, 0 in 2
    			Console.WriteLine(f.Foobar); //123 in both
    			b.Biz=new Foo();
    			b.Biz.Foobar=5;
    			Console.WriteLine(b.Biz.Foobar); //5 in behavior 1, 0 in 2
    			Console.WriteLine(f.Foobar); //567 in behavior 1, 123 in 2
    		}
    	}
    }
