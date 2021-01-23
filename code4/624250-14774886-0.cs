    public class A
    {
        public event EventHandler MyEvent = null;
        public void RaiseMyEvent(EventArgs args)
        {
            var handler = MyEvent;
            if(handler != null)
            {
                handler(this, args);
            }
        }
    }
    //Then, from inside class B:
    myInstanceOfA.RaiseMyEvent();  //This will cause A to raise its own event
