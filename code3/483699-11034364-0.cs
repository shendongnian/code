    public class B
    {
        private A a;
    
        public B(A a)
        {
           this.a = a;
        }
    
        public void UseAFunction()
        {
            a.MyFunction();
        }
    }
