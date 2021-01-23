    class TestClass
    {
        these are the events of the class:
        public event MapChangedEventHandler SomeEvent1;
        public event MapChangedEventHandler SomeEvent2;
        public event MapChangedEventHandler SomeEvent3;
        //now this method calls the events (events can only be raised from inside the class)
        public void SomeMethod()
        {
            //do lots of stuff
            if (SomeEvent1 != null) SomeEvent1(whatever arguments it takes);
            //do other stuff
            if (SomeEvent2 != null) SomeEvent2(another arguments);
        }
        //now, if you want to let derived classes to raise events...
        protected void OnSomeEvent3(Same Parameters As MapChangedEventHandler)
        {
            if (SomeEvent3 != null) SomeEvent3(parameters);
        }
    }
