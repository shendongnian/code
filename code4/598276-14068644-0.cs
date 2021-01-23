        PropertyInfo[] propertyInfos = typeof(Product).GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var inner = propertyInfo.PropertyType.GetProperties().ToList();
            }
    public class Product
    {
        public ProductSpec Spec { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class  ProductSpec
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
