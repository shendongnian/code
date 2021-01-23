    class MyClass {
    	public MyClass Parent { get; set; }
    }
    void Main()
    {
    	MyClass a = new MyClass();
    	a.Parent = new MyClass();
    	a.Parent.Parent = new MyClass();
    	a.AncestorCount(myObj => myObj.Parent); // Output: 2
        a.Ancestors(myObj => myObj.Parent).Count(); // Same result, more flexibility
    }
