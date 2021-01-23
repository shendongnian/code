    interface INamable { string Name { get; } }
    
    class AThingWithAName : INamable 
    {
    	public string Name {get {return "thing";}}
    }
    
    class AnotherThingWithAName : INamable 
    {
    	public string Name {get {return "different thing";}}
    }
    
    class Foo<T> where T : INamable
    {
    	public string Greet(T item) {return "hi " + item;}
    }
