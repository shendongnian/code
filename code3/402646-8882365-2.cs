    void Main()
    {
        using (MyClass myClass = new MyClass())
        {
            while(true)
            {
            }
        }
    }
    public class MyClass : IDisposable
    {
        System.Threading.Timer _timer;
        int _functionNumber = 1;
        bool _disposed;
        public MyClass()
        {
            _timer = new System.Threading.Timer(MyMethod, null, 0, 30000);
        }
        ~MyClass()
        {
            Dispose(false);
        }
		
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
				
        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (_timer != null) _timer.Dispose();
                _disposed = true;
            }
        }
		
        // Timer callback method
        private void MyMethod(object state)
        {
            if (_functionNumber == 1)
            {	
                function1();
                _functionNumber = 2;
            }
            else
            {
                function2();
                _functionNumber = 1;
            }
        }
	
        //Function1
        public int function1()
        {
            ...//some code
        }
        //function2
        public double function2()
        {
            ...//some code
        }
    }
