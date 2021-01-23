    public class ObjectABase
    {
       public virtual int Id {get; set;}
       public virtual string PropertyA {get; set}  
       public virtual string PropertyB {get; set}  
    }
    
    public class ObjectA : ObjectABase
    {
       public virtual string PropertyC {get; set}  
       public virtual string PropertyD {get; set}    
    }
