    class A
    {
        B b;
    
        public A(B b)
        {
            this.b = b;
            // subscribe to event
            b.SomethingHappened += MyMethod;
        }
    
        private void MyMethod() { }
    }
    
    class B
    {
        // declare event
        public event Action SomethingHappened;
    
        private void Button_Click(object o, EventArgs s)
        {
             // raise event
             if (SomethingHappened != null)
                 SomethingHappened();
    
             SomeMethod();
        }
    
        public void SomeMethod() { }
    }
