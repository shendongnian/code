    public static AttributeFetcher<T, TProperty> FetchFrom<T, TProperty>
        (this T instance, Expression<Func<T, TProperty>> propertySelector)
    {
        return new AttributeFetcher<T, TProperty>(instance, propertySelector);     
    }
    public class AttributeFetcher<T, TProperty>
    {
        private readonly T instance;
        private readonly Expression<Func<T, TProperty>> propertySelector;
        // Add obvious constructor
        public U Attribute<U>() where U : Attribute
        {
            // Code as before
        }
    }
