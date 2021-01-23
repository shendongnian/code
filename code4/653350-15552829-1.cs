    class Child
    {
        public Child(Parent p)
        {
          parent=p;
        }
        void SomeMethod()
        {
            // Here I want to call Parent.MethodToCall()
            parent.DoSth();
        }
    }
