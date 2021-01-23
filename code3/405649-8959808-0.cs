    enum MyEnum {
       [Creates(typeof(FooStrategy))]
       Foo,
       [Creates(typeof(BarStrategy))]
       Bar,
       // etc.
    }
    [AttributeUsage(AttributeTargets.Field, Inherited=false, AllowMultiple=false)]
    sealed class CreatesAttribute : Attribute {
        public Type TypeToCreate { get; private set; }
        public CreatesAttribute(Type typeToCreate) {
            TypeToCreate = typeToCreate;
        }
        public static IDictionary<T, Func<U>> GenerateLookup<T,U>() {
           var query = from field in typeof(T).GetFields()
                       let creates = field.GetCustomAttriubtes(typeof(CreatesAttribute), false) as CreatesAttribute[]
                       let method = CreationMethod(typeof(U)) // create your type here
                       let key = (T)field.GetValue(null)
                       select new { Key = key, Method = method };
           return q.ToDictionary(item => item.Key, item => item.Method);
        }
    }
