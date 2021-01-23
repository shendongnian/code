    void Main()
    {
    	var t = new Test();
    	t.Run();
    }
    class ParaA {}
    class ParaB : ParaA {}
    class ParaC : ParaB {}
    
    class TheBaseClass 
    {
       public void DoJob (ParaA a){Console.WriteLine ("DoJob in TheBaseClass is being invoked");}
    
    }
    
    class TheDerivedClass : TheBaseClass 
    {
      public  void DoJob (ParaB b){Console.WriteLine ("DoJob in TheDerivedClass is being invoked");}
    }
    
    public class Test
    {
    	public void Run()
    	{
    		//Case 1: which version of DoJob() is being called?
    		TheDerivedClass aInstance= new TheDerivedClass ();
    		aInstance.DoJob(new ParaA ());
    		
    		//Case 2: which version of DoJob() is being called?
    		TheBaseClass aInstance2= new TheDerivedClass ();
    		aInstance2.DoJob(new ParaA ());
    		
    		//Case 3: which version of DoJob() is being called?
    		TheBaseClass aInstance3= new TheDerivedClass ();
    		aInstance3.DoJob(new ParaB ());
    		
    		//Case 4: which version of DoJob() is being called?
    		TheBaseClass aInstance4= new TheDerivedClass ();
    		aInstance4.DoJob(new ParaC ());
    	}
    }
