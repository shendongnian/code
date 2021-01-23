    void Main()
    {
    	ClassA a = new ClassA();
    	a.MainFunc();
    }
    
    public class TestAbstract
    {
        public virtual void MainFunc()
    	{
    	Func1();
    	Func2();
    	}
    	public virtual void Func1() { "func1".Dump();}
        public virtual void Func2() { "func2".Dump();}
    }
    
    public class ClassA : TestAbstract
    {
        public override void MainFunc()
        {
            //code for line 1
            //code for line 2
            //...
     base.MainFunc();
            //code for line 10
        }
    
    }
    public class ClassB : TestAbstract
    {
        public override void MainFunc()
        {
            //code for line 1
            //code for line 2
            //...
    		base.MainFunc();
            //code for line 10
        }
        public override void Func1() { "func1".Dump();}
        public override void Func2() { }
    }
