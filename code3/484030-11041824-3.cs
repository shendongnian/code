    class Foo 
    { 
        public string Name { get; set; }
        public Foo(string name)
        {
            Name = name;
        }
    
        public override bool Equals(object obj)
        {
            // error and type checking go here!
            return ((Foo)obj).Name == this.Name;
        }
    
        // should override GetHashCode as well
    }
    class Program
    {
    	static void Main( string[] args )
    	{
    		var x = new Foo("ed");
    		var y = new Foo("ed");
    		Console.WriteLine(x.Equals(y));  // prints "True"
    		Console.Read();
    	}		
    }
