    public abstract class Entity
    {
        public int Id { get; set; }
    }
    public class Product : Entity
    {
    
    }
    public class Warehouse : Product
    { 
        /* all product fields are available */   
    }
    public class User : Product
    {
        /* all product fields are available */
    }
