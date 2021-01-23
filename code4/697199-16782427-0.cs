    public interface IPlugin {
       string Foo { get; set;}
    }
    
    public class A : IPlugin {
    
       private static A _inslance { get; set;}
       
    	public static A Instance {
            get {
    	        if (_inslance == null){
    		        _inslance = new A();
    	        }
    	        return _inslance;
            }
       }
    
    
       public string Foo { get; set;}
    }
    
    public class B : IPlugin {
    
       public string GetMeFooOfA {
            get {
    	        return A.Instance.Foo;
            }
       }
    
       public string Foo { get; set;}
    }
    		
    void Main()
    {
    	A.Instance.Foo = "Test 123";
    	
    	var b = new B();
    	
    	Console.WriteLine(b.GetMeFooOfA);
    }
