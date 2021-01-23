    public class SomeBaseClass
    {
    }
    public class MyComposedClass : SomeBaseClass, IMyInterface
    {
        private readonly IMyInterface _myInterface = new ConcreteMyInterface();
        public void MyAction()
        {
            _myInterface.MyAction();
        }
    }
