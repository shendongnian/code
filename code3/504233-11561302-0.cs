    class Program
    {
        static void Main()
        {
              GenericCollection<BusinessEntity> businessCollection = new BusinessCollection();
              //this will work
              BusinessCollection tempCollection = (BusinessCollection)businessCollection ;
        }
    }
    
    
    
    public class BusinessEntity
    {
       public string Foo { get; set;}
    }
    public class BusinessCollection : GenericCollection<BusinessEntity>
    {
         //some implementation here
    }
    
    public class GenericCollection<T> : ICollection<T>
    {
        //some implementation here
    }
