        static IEnumerable<FieldInfo> GetSerializableFields(Type type, Func<Type, IEnumerable<FieldInfo>> andNext)
        {
            return 
                (type.IsInterface || type == typeof(object))
                ? new FieldInfo[0]
                : type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                      .Where(f => (f.Attributes & FieldAttributes.NotSerialized) != FieldAttributes.NotSerialized)
                      .Concat(andNext(type))
                      .ToArray();
        }
        static void PrintMemberInfo(Type t)
        {
            Console.WriteLine(t.Name);
            Func<Type, IEnumerable<FieldInfo>> andNext = null;
            andNext = tp => GetSerializableFields(tp.BaseType, andNext);
            var fields = GetSerializableFields(t, tp => new FieldInfo[0]).ToArray();
            var base_fields = GetSerializableFields(t.BaseType, andNext).ToArray();
            var counter = 0;
            foreach (var f in fields.Concat(base_fields))
            {
                Console.WriteLine(
                    "{0} Reflected: {1} - Declaring: {2} - Field: {3} ({4})", 
                    (counter++) + 1, f.ReflectedType.Name, f.DeclaringType.Name, f.Name, f.MetadataToken);
            }
            Console.WriteLine();
        }
    }
