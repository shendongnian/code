     public sealed class Myclass
     {
            static Myclass()
            {
                Myclass.Application = new Myclass();
            }
    
           .....
            public static Myclass Application {get;set;}
            ...
    
    
    }
