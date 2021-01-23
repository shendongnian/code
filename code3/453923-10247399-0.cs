    public class BaseClass<T>
    {
       public T NestedClass{get;set;}
    }
    
    public  class MainOne : BaseClass<MainOneType>
    {
    }
    
    public class MainTwo : BaseClass<MainTwoType>
    {
    }
    
    public class MainOneType
    {
    }
    
    public class MainTwoType
    {
    }
