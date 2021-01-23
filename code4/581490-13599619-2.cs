    public class MyClass<P, Q>
    {
        static MyClass() 
        {
           if (IsValidType(typeof(P) 
               && IsValidType(typeof(Q)) // need 2 '&' here but SO won't let me post them!
           throw new NotSupportedException("invalid type for MyDataStructure");
        }
        static bool IsValidType(Type type)
        {
           // logic to check whether type is acceptable
           return true;
        }
    }
