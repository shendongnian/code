    public class MyFactory
    {
        static private MyFactory _factory;
    
        static MyFactory()
        {
            _factory = new MyFactory();
        }
    
        ~MyFactory()
        {
            // Do Cleanup
        }
    }
