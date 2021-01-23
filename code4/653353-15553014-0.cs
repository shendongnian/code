    class Child : Parent
    {
        private void SomeMethod()
        {
            base.MethodToCall();
        }
    }
    class Parent
    {
        Child c = new Child();
        protected void MethodToCall()
        {
            c.MethodToCall();//not sure if you are wanting to call c.MethodToCall();
        }
    }
