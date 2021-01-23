    public interface MyListener { // This is probably your MyEvent
        void myEventFired(Object sender, MyEventArgs eventArgs);
    }
    public class MyEventArgs {
        ...something...
    }
