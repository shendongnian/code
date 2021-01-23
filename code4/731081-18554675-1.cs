    public class MyClassInvoker:IDisposable
    {
        readonly Timer _myTimer;
        readonly MyClass _myclass;
        public MyClassInvoker(MyClass myclass)
        {
            _myTimer = new Timer();
            _myclass = myclass;
            
        }
        public void Start()
        {
            _myTimer.Interval = 3000;//configure Your timer here
            //add or remove any previous listeners 
            //here depending upon the business needs
            
            _myTimer.Elapsed += new ElapsedEventHandler(PeriodicInvoker); 
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
