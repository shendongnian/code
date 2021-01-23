    [CLSCompliant(true)]
    public class Program
    {
        private MyObject _myObject;
        [CLSCompliant(true)]
        public MyObject ComplaintTypeBO
        {
            get { return _myObject ?? (_myObject = new MyObject()); }
        }
        static void Main(string[] args)
        {
        }
    }
    
    [CLSCompliant(true)]
    public class MyObject
    {
    }
