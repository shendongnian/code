    public class MyEvent: CompositePresentationEvent<MyEventArgs> {}
    
    public class MyEventArgs { int MyIntValue; }
    
    public class Subscriber
    {
      public Subscriber
      {
        eventAggregator.GetEvent<MyEvent>().Subscribe(SomeMethod);
      }
    
      public void SomeMethod(MyEventArgs e)
      {
        MessageBox.Show(e.MyIntValue);
      }
    }
    public class Publisher
    {
      public void SendMinusOne()
      {
        var args = new MyEventArgs() { MyIntValue = -1 };
        eventAggregator.GetEvent<MyEvent>().Publish(args);
      }
    }
