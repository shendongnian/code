    public class MyBase
    {
        public int A;
    }
    public class MyDerived : MyBase
    {
        public int B;
        public MyDerived(MyBase obj)
        {
            A = obj.A;
        }
    }
 
    public void MyMethod() {
        List<MyBase> baseCollection = GetBaseCollection();
        List<MyDerived> derivedCollection = baseCollection.Select(x => new MyDerived(x)).ToList();
    }
