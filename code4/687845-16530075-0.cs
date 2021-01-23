    class Program
    {
        public static class TupleSerializer<T>
        {
            public static DataContractSerializer Create()
            {
                if ((typeof(T).GetGenericTypeDefinition() == typeof(Tuple<,>)) ||
                   (typeof(T).GetGenericTypeDefinition() == typeof(Tuple<,,>)))
                    return new DataContractSerializer(typeof(T), typeof(T).GetGenericArguments());
                else
                    throw new NotSupportedException();
            }
        }
        
        static void Main(string[] args)
        {
            var x = Tuple.Create(Guid.NewGuid(), new[] { 1, 2, 3, 4, 5, 6 });
            var serializer = TupleSerializer<Tuple<Guid, int[]>>.Create();
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.WriteObject(writer, x);
                writer.Flush();
                Console.WriteLine(sb.ToString());
            }
        }
    }
