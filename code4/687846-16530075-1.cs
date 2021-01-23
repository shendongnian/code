    class Program
    {
        public static class DataContractSerializerFactory<T>
        {
            private static IEnumerable<Type> GetTypeArguments(Type t, IEnumerable<Type> values)
            {
                if (t.IsGenericType)
                    foreach (var arg in t.GetGenericArguments())
                        values = values.Union(GetTypeArguments(arg, values));
                else
                    values = values.Union(new[] { t });
                return values;
            }
            
            public static DataContractSerializer Create()
            {
                return new DataContractSerializer(typeof(T), GetTypeArguments(typeof(T), new[] { typeof(T) }));
            }
        }
        
        static void Main(string[] args)
        {
            var x = Tuple.Create(Guid.NewGuid(), new[] { 1, 2, 3, 4, 5, 6 });
            var serializer = DataContractSerializerFactory<Tuple<Guid, int[]>>.Create();
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.WriteObject(writer, x);
                writer.Flush();
                Console.WriteLine(sb.ToString());
            }
        }
    }
