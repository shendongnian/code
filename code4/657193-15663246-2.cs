    class BaseClass
    {
    	public string Property {get; set;}
    }
    
    class DerivedClass : BaseClass
    {
        //compiler will give you a hint here, that you are hiding a base class prop
    	public string Property {get; set;}
    }
