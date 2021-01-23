    void Main()
    {
        //resolve the inner type
        var  parameterType = Type.GetType("UserQuery+GenericParameter");
        
        //Use the generic type, and generate with the inner parameter type
        var genericTypeWithParameter = Type.GetType("UserQuery+Moop`1")
            .MakeGenericType(parameterType);
        
        //The resolved type - printed to console
        genericTypeWithParameter.Dump();
    }
    
    public class Moop <T> { }
    public class GenericParameter { }
