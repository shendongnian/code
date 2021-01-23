    class Base
    {
        protected static readonly Dictionary<DerivedType, int[]> SomeDict;
        static Base()
        {
            SomeDict = new Dictionary<DerivedType, int[]>();
            SomeDict.Add(DerivedType.Type1, new int[] { 1, 2, 3, 4 });
            SomeDict.Add(DerivedType.Type2, new int[] { 4, 3, 2, 1 });
            SomeDict.Add(DerivedType.Type3, new int[] { 5, 6, 7 });
            // ...
        }
        public static int[] SomeArray(DerivedType type)
        {
            return SomeDict[type];
        }
    }
    public enum DerivedType
    {
        Type1, Type2, Type3, Type4, Type5
    }
    class Derived : Base
    {
        public override DerivedType Type
        {
            get { return DerivedType.Type1; }
        }
    }
