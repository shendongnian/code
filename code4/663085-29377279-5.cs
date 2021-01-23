    class MyClass {
    	public MyClass Parent { get; set; }
    }
    void Main()
    {
    	MyClass a = new MyClass();
    	a.Parent = new MyClass();
    	a.Parent.Parent = new MyClass();
    	a.Ancestors(myObj => myObj.Parent).Count(); // Result: 2
    }
