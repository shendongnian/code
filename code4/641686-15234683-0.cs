    public class Program
    {
        public static void PrintProperties<T>(T t)
        {
            var properties = t.GetType().GetProperties();
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(t, null);
                if (property.PropertyType.IsGenericType && property.PropertyType == typeof(IEnumerable<>))
                {
                    var formatList = typeof(Program).GetMethod("FormatList", new[] { value.GetType() });
                    formatList.MakeGenericMethod(value.GetType().GetGenericArguments().First());
                    value = formatList.Invoke(null, new object[] { value });
                    Console.Out.WriteLine(name + ": " + value);
                }
                else
                {
                    Console.Out.WriteLine(name + ": " + value);
                }
            }
        }
        public static string FormatList<TPlaceholder>(IEnumerable<TPlaceholder> l)
        {
            return string.Join(", ", l);
        }
    }
