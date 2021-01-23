    public class A
    {
        public List<B> MyCollection{get; set;}
    }
    
    public class B
    {
    	 public string Id;
    }
    
    void Main()
    {
    	// this is what you're searching for
    	var myB = new B{Id="1"};
    
    	// here are some A objects to put in your collection
    	A a1 = new A();
    	a1.MyCollection = new List<B>();
    	A a2 = new A();
    	a2.MyCollection = new List<B> { myB };
    	A a3 = new A();
    	a3.MyCollection = new List<B> { new B {Id="1"}};
    	
    	// here's a List that represents your context.A
    	List<A> contextA = new List<A> {a1, a2, a3};
    	
    	
    	// here's your actual search. results has a count of 1
    	var results = contextA.Where( x=> x.MyCollection.Contains(myB));
    	Console.WriteLine(results.Count()); 
    }
