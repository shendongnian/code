    public class Program
    {
        public static void Main(string[] args)
        {                        
            Client.Instance.MyEvent += delegate { Console.WriteLine("MY EVENT handled from Main"); };
            
            MyTest mt = new MyTest();
            
            Type mType = typeof(MyTest);
            object reflectedMT = Activator.CreateInstance(mType);
            
            Client.Instance.FireEvent();
        }
    }
    
    public class Client {
        private Client() {}
        private static Client _inst = new Client();
        public static Client Instance { get { return _inst; } }
        public void FireEvent() { if(MyEvent != null) MyEvent(this, EventArgs.Empty); }
        public event EventHandler<EventArgs> MyEvent;
    }
    
    public class MyTest {
       public MyTest() {
          System.Console.WriteLine("In Constructor Registering Events");
          Client.Instance.MyEvent += new EventHandler<EventArgs>(myHandler);
       }
       private void myHandler(object sender, EventArgs arg) {
          System.Console.WriteLine("Got event!");
       }
    }
