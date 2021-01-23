    class B
    {
        //A public event for listeners to subscribe to
        public event EventHandler SomethingHappened;
        private void Button_Click(object o, EventArgs s)
        {
            //Fire the event - notifying all subscribers
            if(SomethingHappened != null)
                SomethingHappened(this, null);
        }
    ....
    
    class A
    {
        //Where B is used - subscribe to it's public event
        public A()
        {
            B objectToSubscribeTo = new B();
            objectToSubscribeTo.SomethingHappened += HandleSomethingHappening;
        }
        
        public void HandleSomethingHappening(object sender, EventArgs e)
        {
            //Do something here
        }
    
    ....
