    public class Shadam
    {
        object DataSource { get; set; }
        public void OrderList(string myType, string myProperty)
        {
            Type type = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                         from item in asm.GetTypes()
                         where item.IsClass && item.Name.Equals(myType)
                         select item).Single();
            var property = type.GetProperty(myProperty);
            typeof(Shadam).GetMethod("OrderGenericList")
                          .MakeGenericMethod(type, property.PropertyType)
                          .Invoke(this, new[] { property });
        }
        public void OrderGenericList<T, TProperty>(PropertyInfo property)
        {
            var tParameter = Expression.Parameter(typeof(T));
            var orderExpression = Expression.Lambda<Func<T, TProperty>>(
                                      Expression.Property(tParameter, property),
                                      tParameter
                                  ).Compile();
            
            this.DataSource = ((List<T>)this.DataSource).OrderBy(orderExpression);
        }
    }
