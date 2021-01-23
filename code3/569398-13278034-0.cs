    public class MyTypeList<T> : Collection<Type>
    {
        protected override InsertItem( int index, Type item )
        {
            if( !typeof(T).IsAssignableFrom(item) )
            {
                throw new ArgumentException("the Type does not derive from ... ");
            }
    
            base.InsertItem(index, item);
        }
    }
