     static void Main(string[] args)
        {
            var strings = new[] { "1","2","3"};
            var ints = strings.ConvertItems<string, int>().ToList();
            var doubles = strings.ConvertItems<string, double>().ToList();
            var nullableints = strings.ConvertItems<string, int?>().ToList();
        }
        public static IEnumerable<TargetType> ConvertItems<SourceType, TargetType>(this IEnumerable<SourceType> sourceCollection)
        {
            var targetType = typeof(TargetType);
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetType = targetType.GetGenericArguments().First();
            }
            return sourceCollection.ConvertItems((source) => (TargetType)Convert.ChangeType(source, targetType));
        }
        public static IEnumerable<TargetType> ConvertItems<SourceType, TargetType>(this IEnumerable<SourceType> sourceCollection, Converter<SourceType, TargetType> convertor)
        {
            foreach (var item in sourceCollection)
            {
                yield return convertor(item);
            }
        }
