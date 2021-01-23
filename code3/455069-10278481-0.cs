    public class FDTObject {}
    public class MyDTObject1 : FDTObject {}
    public class MyDTObject2 : FDTObject { }
    
    public class ObjectTypeCollection : Collection<Type>
    {
        protected override void InsertItem(int index, Type item)
        {
            if (!typeof(FDTObject).IsAssignableFrom(item))
            {
                throw new ArgumentException(string.Format("Type {0} is not valid", item));
            }
            base.InsertItem(index, item);
        }
    }
