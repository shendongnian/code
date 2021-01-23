    class Child
    {
        Parent parent=null;
        public Child(Parent p)
        {
          parent=p;
        }
        void SomeMethod()
        {           
            parent.MethodToCall();
        }
    }
