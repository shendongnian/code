    static void Main(string[] args)
        {
            var strings = new[] { "1","2","3"};
            var ints = strings.ConvertItems(typeof(int));
            var doubles = strings.ConvertItems(typeof(double));
            var nullableints = strings.ConvertItems(typeof(int?));
            foreach (int? item in nullableints)
            {
                Console.WriteLine(item);
            }
        }
        public static IEnumerable ConvertItems(this IEnumerable sourceCollection,Type targetType)
        {
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetType = targetType.GetGenericArguments().First();
            }
            foreach (var item in sourceCollection)
            {
                yield return Convert.ChangeType(item, targetType);
            }
        }
