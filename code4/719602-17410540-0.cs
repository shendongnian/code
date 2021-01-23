    public class MyClass {
        private static readonly MyObject obj;
        private static readonly List<MyObject> listObject;
        static SimpleClass()
        {
            listObject = new List<MyObject> { new MyObject() };
            obj = new MyObject { parent = listObject[0] };
        }
    }
