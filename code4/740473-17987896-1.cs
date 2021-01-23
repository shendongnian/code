    public class TypeClass
    {
        public static T[] CreateArray<T>(int arrayLength) // using T[] would save you from type-casting
            where T : new()     // <-- Constrain to types with a default constructor
        {
            T[] t = new T[arrayLength];
            for (int j = 0; j < arrayLength; j++)
                t[j] = new T();
            return t;
        }
    }
    public class MyClass
    {
        static void Main(string[] args)
        {
            int [] intArray = TypeClass.CreateArray<int>(5);
            string [] stringArray = TypeClass.CreateArray<string>(5);
            Point [] pointArray = TypeClass.CreateArray<Point>(5);
            MyCustomClass [] myCustomClassArray = TypeClass.CreateArray<MyCustomClass>(5);
        }
    }
