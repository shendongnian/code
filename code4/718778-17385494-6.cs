    public static class WidgetUtil<T1, T2>
    {
        public static readonly IEnumerable<Tuple<PropertyInfo, PropertyInfo>> PropertyMap;
        static Util()
        {
            var b = BindingFlags.Public | BindingFlags.Instance;
            PropertyMap = 
                (from f in typeof(T1).GetProperties(b)
                 join t in typeof(T2).GetProperties(b) on f.Name equals t.Name
                 select Tuple.Create(f, t))
                .ToArray();
        }
    }
