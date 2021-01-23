    void Main()
    {
    	Foo A = new Foo{Age = 16}; //A creates a space in memory for the data of Foo and points to that memory location
    	Foo B = A; //B just creates a variable and points to the memory location created by A
    	
    	A.Bar();
    	B.Bar();
    	
    	//Result
    	//Your Age is 16
        //Your Age is 16
    	
    	A.Age = 24;
    	
    	A.Bar();
    	B.Bar();
    	
    	//Result
    	//Your Age is 24
        //Your Age is 24  <----- B is pointing to the same location as A and reflects the changes on call.
    	
    	FooValueType E = new FooValueType{Age = 23};
    	FooValueType F = E;
    	
    	E.Bar();
    	F.Bar();
    	
    	//Result
    	//Your Age is 23
    	//Your Age is 23
    	
    	E.Age = 56;
    	
    	E.Bar();
    	F.Bar();
    	
    	//Result
    	//Your Age is 56
    	//Your Age is 23
    }
    
    public class Foo  //These object are by reference
    {
        public int Age { get; set; }
    	public void Bar()
    	{
    	   Console.WriteLine("Your Age is {0}", Age);
    	}
    }
    
    public struct FooValueType //These object are by value
    {
        public int Age { get; set; }
    	public void Bar()
    	{
    	   Console.WriteLine("Your Age is {0}", Age);
    	}
    }
