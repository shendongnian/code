    public class MyClassInvoker:IDisposable
    {
        readonly Timer _myTimer;
        readonly MyClass _myclass;
        public MyClassInvoker(Timer myTimer, MyClass myclass)
        {
            _myTimer = myTimer;
            _myclass = myclass;
            _myTimer.Interval = 3000;//configure Your timer here
            _myTimer.Elapsed +=new ElapsedEventHandler(PeriodicInvoker); 
        }
        public void Start()
        {
            _myTimer.Start();
        }
        public void Dispose()
        {
            _myTimer.Dispose();
        }
        void PeriodicInvoker(object sender, EventArgs e)
        {
            _myclass.DoSomePeriodicWork();
        }
    }
