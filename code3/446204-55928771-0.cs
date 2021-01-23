    class Base
    {
	     public void DoWork()
	     {
		     Console.WriteLine("Base.DoesWork");
	     }
    }
    class Derived : Base
    {
	    public void DoWork()  
        // warning Derived.DoWork() hides inherited member Base.DoWork(). 
        // Use the new keyword if hiding was intended
	    {
		    Console.WriteLine("Derived.DoesWork");
	    }
    }
