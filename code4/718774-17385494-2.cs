    public static class WidgetUtil
    {
        public static readonly IEnumerable<Tuple<PropertyInfo, PropertyInfo>> PropertyMap;
        static Util()
        {
            var b = BindingFlags.Public | BindingFlags.Instance;
            PropertyMap = 
                (from f in typeof(Widget).GetProperties(b)
                 join t in typeof(WidgetChange).GetProperties(b) on f.Name equals t.Name
                 select Tuple.Create(f, t))
                .ToArray();
        }
    }
    ...
    foreach(var propertyPair in WidgetUtil.PropertyMap)
    {
        var toValue = propertyPair.Item2.GetValue(widget_diff, null);
        if (!toValue.Equals(null))
        {
            propertyPair.Item1.SetValue(widget, toValue, null);
        }
    }
