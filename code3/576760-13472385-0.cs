    public class MyClass1
    {
        public void ServiceCallComplete()
        {
            Console.WriteLine("Function returned.");
        }
    }
    public class Service
    {
        private readonly Action _callBack;
        public Service(Action callBack)
        {
            _callBack = callBack;
        }
        public void Method()
        {
            //long running operation
            _callBack();
        }
    }
    MyClass1 obj = new MyClass1();
    Service svc = new Service(obj.ServiceCallComplete);
    svc.Method();
