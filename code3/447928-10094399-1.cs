    public class ClassB {
        // Note the syntax at the end here- the "(s, e) => { }" 
        // assigns a no-op listener so that you don't have to 
        // check the event for null before raising it.
        public event EventHandler<MyEventArgs> MyEvent = (s, e) => { }
    
        public void DoMyWork() { 
            // Do whatever
  
            // Then notify listeners that the event was fired
            MyEvent(this, new MyEventArgs(myWorkResult));
        }
    }
    
    public class ClassA {
        public ClassA(ClassB worker) {
            // Attach to worker's event
            worker.MyEvent += MyEventHandler;
 
            // If you want to detach later, use
            // worker.MyEvent -= MyEventHandler;
        }
    
        void MyEventHandler(Object sender, MyEventArgs e) {
            // This will get fired when B's event is raised
        }
    }
    public class MyEventArgs : EventArgs {
        public String MyWorkResult { get; private set; }
        public MyEventArgs(String myWorkResult) { MyWorkResult = myWorkResult; }
    }
