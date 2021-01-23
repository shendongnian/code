    public class Base
    {
         public virtual void DoSomething(string param="Hello", string param1 = "Bye") 
         {
     	
    	Console.WriteLine(string.Format("prm: {0}, prm1: {1}", param, param1));
         }
    }
    
    public class Derived  : Base
    {
    	public override void  DoSomething(string param="Ciao", string param1="Ciao")
    	{
    	      Console.WriteLine(string.Format("prm: {0}, prm1: {1}", param, param1));
    	}
    }
