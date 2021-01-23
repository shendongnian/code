    public delegate void MyEventHandler(string result);
    public class MyClass
    {
      public event MyEventHandler MyEvent;
      private void Event(string result)
      {
        MyEventHandler handler = MyEvent;
        if(handler != null)
          handler(result);
      }
      
      public void DoSomethingLong()
      {
        //Do something
        Event("Finish");
      }
    }
