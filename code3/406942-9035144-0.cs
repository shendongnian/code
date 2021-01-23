    /// <summary>
    /// Defaultvalues für nicht (mehr) benötigte Spalten siehe
    /// http://elegantcode.com/2009/07/13/using-nhibernate-for-legacy-databases/
    /// </summary>
    public abstract class DefaultValuesBase : IPropertyAccessor
    {
        public abstract IEnumerable<IGetter> DefaultValueGetters { get; }
        public bool CanAccessThroughReflectionOptimizer
        {
            get { return false; }
        }
        public IGetter GetGetter(Type theClass, string propertyName)
        {
            return DefaultValueGetters.SingleOrDefault(getter => getter.PropertyName == propertyName);
        }
        public ISetter GetSetter(Type theClass, string propertyName)
        {
            return new NoopSetter();
        }
    }
    // taken from the link
    [Serializable]
    public class DefaultValueGetter<T> : IGetter {...}
    // ---- and the most tricky part ----
    public static void DefaultValues<T>(this ClasslikeMapBase<T> map, DefaultValuesBase defaults)
    {
        DefaultValuesInternal<T>(map.Map, defaults);
    }
    public static void DefaultValues<T>(this CompositeElementPart<T> map, DefaultValuesBase defaults)
    {
        DefaultValuesInternal<T>(map.Map, defaults);
    }
    private static void DefaultValuesInternal<T>(
        Func<Expression<Func<T, object>>, PropertyPart> mapFunction, DefaultValuesBase defaults)
    {
        var noopSetter = new NoopSetter();
        var defaultsType = defaults.GetType();
        foreach (var defaultgetter in defaults.DefaultValueGetters)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression body = Expression.Property(parameter,
                new GetterSetterPropertyInfo(typeof(T), defaultgetter, noopSetter));
            body = Expression.Convert(body, typeof(object));
            var lambda = Expression.Lambda<Func<T, object>>(body, parameter);
            mapFunction(lambda).Column(defaultgetter.PropertyName).Access.Using(defaultsType);
        }
    }
    // GetterSetterPropertyInfo inherits PropertyInfo with important part
    public override string Name
    {
        get { return m_getter.PropertyName; } // propertyName is the column in db
    }
    // and finally in SomeEntityMap
    this.DefaultValues(new SomeEntityDefaults());
    public class SomeEntityDefaults : DefaultValuesBase
    {
        public override IEnumerable<IGetter> DefaultValueGetters
        {
            get
            {
                return new [] {
                    new DefaultValueGetter<int>("someColumn", 1),
                    new DefaultValueGetter<string>("somestrColumn", "empty"),
                };
            }
        }
    }
