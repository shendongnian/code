    public class MyClass
    {
        public ReadOnlyCollection<MyItemClass> MyReadOnlyCollection { get; private set; }
     
        public MyClass()
        {
            List<MyItemClass> list = new List<MyItemClass>() { ... };
            MyReadOnlyCollection = new ReadOnlyCollection<MyItemClass>(list);
        }
    }
