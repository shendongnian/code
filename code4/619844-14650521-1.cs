    public class MyClass
    {
        private List<MyItemClass> list;
        public ReadOnlyCollection<MyItemClass> MyReadOnlyCollection { get; private set; }
     
        public MyClass()
        {
            list = new List<MyItemClass>() { ... };
            MyReadOnlyCollection = new ReadOnlyCollection<MyItemClass>(list);
        }
    }
