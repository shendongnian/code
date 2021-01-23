    public abstract class Parent
    {
    	public int val;
    
    	public Parent()
    	{
    		val = 0;
    	}
    
    	public virtual void foo()
    	{
    		MethodInfo method = typeof(Parent).GetMethod("inc");
    		DynamicMethod dm = new DynamicMethod("BaseInc", null, new Type[] { typeof(Parent) }, typeof(Parent));
    		ILGenerator gen = dm.GetILGenerator();
    		gen.Emit(OpCodes.Ldarg_1);
    		gen.Emit(OpCodes.Call, method);
    		gen.Emit(OpCodes.Ret);
    
    		var BaseInc = (Action<Parent>)dm.CreateDelegate(typeof(Action<Parent>));
    		BaseInc(this);
    	}
    
    	public virtual void inc()
    	{
    		val = val + 10;
    	}
    }
