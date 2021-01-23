    static IDictionary<string, Func<Obj, object>> gettersCache = new Dictionary<string, Func<Obj, object>>();
    static void InitializeData2<T>(IList objects, PropertyInfo[] props, List<Dictionary<string, object>> tod, IDictionary<string, Func<T, object>> getters) {
        Func<T, object> getter;
        foreach(T item in objects) {
            var kvp = new Dictionary<string, object>();
            foreach(var p in props) {
                if(!getters.TryGetValue(p.Name, out getter)) {
                    getter = GetValueGetter<T>(p);
                    getters.Add(p.Name, getter);
                }
                kvp.Add(p.Name, getter(item));
            }
            tod.Add(kvp);
        }
    }
    static Func<T, object> GetValueGetter<T>(PropertyInfo propertyInfo) {
        var instance = System.Linq.Expressions.Expression.Parameter(propertyInfo.DeclaringType, "i");
        var property = System.Linq.Expressions.Expression.Property(instance, propertyInfo);
        var convert = System.Linq.Expressions.Expression.TypeAs(property, typeof(object));
        return (Func<T, object>)System.Linq.Expressions.Expression.Lambda(convert, instance).Compile();
    }
