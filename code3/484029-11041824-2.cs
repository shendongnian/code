    class Foo 
    { 
        public string Name { get; set; }
        public Foo(string name)
        {
            Name = name;
        }
    }
    class Program
    {
    	static void Main( string[] args )
    	{
    		var x = new Foo("ed");
    		var y = new Foo("ed");
    		Console.WriteLine(x.Equals(y));  // prints "False"
    	}		
    }
