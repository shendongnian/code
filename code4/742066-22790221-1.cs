    public class EnhancedCollectionTypeFactory : DefaultCollectionTypeFactory
    {
           
    
        public override CollectionType Bag<T>(string role, string propertyRef, bool embedded)
        {
               
             return  new EnhancedGenericBagType<T>(role, propertyRef);
        }
    
    }
