    public class MyClass1
    {
        //The callback Function
        public void ServiceCallComplete()
        {
            Console.WriteLine("Function returned.");
        }
    }
    public class Service
    {
        //delegate to store the callback function.
        private readonly Action _callBack;
        public Service(Action callBack)
        {
            //store the callback function
            _callBack = callBack;
        }
        public void Method()
        {
            //long running operation
            .
            .
           //Invoke the callback
            _callBack();
        }
    }
    MyClass1 obj = new MyClass1();
    Service svc = new Service(obj.ServiceCallComplete);
    svc.Method();
