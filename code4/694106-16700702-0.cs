    public class MyClass : IMyInterface, IMyInterface<MyClass>
    {
        public bool MemberwiseCompare(MyClass other) { ... }
    	bool IMyInterface.MemberwiseCompare(object other)
    	{
    		MyClass mc = other as MyClass;
    		return mc != null && this.MemberwiseCompare(mc);
    	}
    }
