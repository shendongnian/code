    public abstract class EntityBase
    {
       public virtual int Id { get; set; } // this will be mapped
       public virtual int DoNotMap { get; set; } // this should be ignored   
    }
