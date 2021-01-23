    public class MyComposedClass : SomeBaseClass, IMyInterface
    {
        private readonly IMyInterface _myInterface = new ConcreteMyInterface();
        public void MyAction()
        {
            _myInterface.MyAction();
        }
        private class ConcreteMyInterface : MyInterfaceBase
        {
            protected override void Function()
            {
                Console.WriteLine("hello");
            }
        }
    }
