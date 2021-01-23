    public static IEnumerable<TSource> OrderByProperties<TSource>(IEnumerable<TSource> source, IEnumerable<string> propertyNames) {
        IEnumerable<TSource> result = source;
        foreach (var propertyName in propertyNames) {
            var localPropertyName = propertyName;
            result = result.OrderByPreserve(x => x.GetType().GetProperty(localPropertyName).GetValue(x, null));
        }
        return result;
    }
