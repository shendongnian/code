    public class Foo<T> where T : struct
    {
        public Nullable<T> Bar { get; set; }
    }
    Type propertyType = typeof(Foo<>).GetProperty("Bar").PropertyType;
    // propertyType is an *open* type...
