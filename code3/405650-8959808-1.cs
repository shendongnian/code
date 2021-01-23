    public static class MyEnumExtensions {
        static readonly IDictionary<MyEnumType, MyBaseStrategyType> lookup = 
            CreatesAttribute.GenerateLookup<MyEnumType, MyBaseStrategyType>();
        public static MyBaseStrategyType CreateInstance(this MyEnumType key) {
              return lookup[key](/* pass any common constructor values */);
        }
    }
