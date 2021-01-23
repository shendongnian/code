    class Program
    {
      static void Main(string[] args)
      {
        var t = new Test();
    
        var e = t.GetType().GetEvent("TestEvent");
        var te = Delegate.CreateDelegate(e.EventHandlerType, new EventHandler(MyMethod).Method);
    
        e.AddEventHandler(t, te);
    
        t.RaiseTest();
      }
    
      static void MyMethod(object sender, object args)
      {
    
      }
    }
    
    public class Test
    {
      public class MyEventArgs : EventArgs { }
    
      public void RaiseTest()
      {
        var e = TestEvent;
        if (e != null)
          e(this, new MyEventArgs());
      }
    
      public event EventHandler<MyEventArgs> TestEvent;
    }
