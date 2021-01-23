    public class Foo  
    {    
       public string Property1 { get; set; } 
    } 
    
    public class Foo<T> : Foo
    {
       public static void AssignDel<TVal>(Expression<Func<T, TVal>> expr, Action<T, TVal> action)
       {   }
    }
    
    public class InheritsFoo : Foo<InheritsFoo>
    {     } 
