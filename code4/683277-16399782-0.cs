    [AttributeUsage( Inherited = true)]
    public class CustomAttribute : Attribute
    {
    }
    
    [Custom]
    public class Base {
    }
    
    public class Sub : Base {
    }
