    class Neuro
    {
        public class Net
        {
            private Neuro _parent;
            public Net(Neuro parent)
            {
             _parent = parent;
            }
            public void SomeMethod()
            {
                _parent.OtherMethod(); 
            }
        }
        public int OtherMethod() 
        {
            return 123;  
        }
    }
