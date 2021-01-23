    public class MyCollection : MyRigCollectionBase<MyObject>
    {
        public static ToMyCollection(this IEnumerable<MyObject> enumerable)
        {
            return new MyCollection(enumerable);   // Calls our previously declared constructor.
        }
    }
