    public interface IEntityFormatter<T>
    {
        string GetFormattedValue(T myEntity);
    }
    
    public class Customer
    {
        public string FullName {get;set;}
    }
    
    public class CustomerFormatter : IEntityFormatter<Customer>
    {
        public string GetFormattedValue(Customer myEntity)
        {
            return myEntity.FullName;
        }
    }
