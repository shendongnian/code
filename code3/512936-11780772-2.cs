    public class MyClass
    {
        public MyResourceType MyResource { get; set; }
        public void DoFirstThing() { ... }
        public void DoSecondThing(){ ... }
    }
    public class MyClassHelper
    {
        private static readonly object _gate = new Object();
        private static MyResourceType MyResource = new MyResourceType();
        private MyClass _myClass = new MyClass();        
        public void DoWork(Action<MyClass> action)
        {
             lock(_gate)
             {
                 _myClass.MyResource = MyResource;
                 action(_myClass);
                 _myClass.MyResource = null;
             }
        }
    }
    ...
    var myClassHelper = new MyClassHelper();
    myClassHelper.DoWork(x => 
        {
            x.DoFirstThing();
            x.DoSecondThing();
        });
