    abstract class B : A
    {
        public string PropertyB { get; set; }
        public override List<PropertyInfo> Foo()
        {
            return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                            .ToList();
        }
    }
