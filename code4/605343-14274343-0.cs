    public class MyClass : ClassA, IClassB
    {
        private IClassB _classB; // delegate IClassB implementation to it
        public MyClass(IClassB classB)
        {
           _classB = classB;
        }
        public void BMethod()
        {
            _classB.BMethod();
        }
    }
